#include "stdafx.h"
#include "amp.h"
#include "TCHAR.h"
#include "pdh.h"
#include "windows.h"
#include <winternl.h>


using namespace concurrency;

extern "C" __declspec (dllexport) int _stdcall sum(int a,int b)
{
	return (a + b);
} 


//1. Общее кол-во виртуальной памяти.
extern "C" __declspec (dllexport) double _stdcall VirtualMemoryTotal()
{
	MEMORYSTATUSEX memInfo;
	memInfo.dwLength = sizeof(MEMORYSTATUSEX);
	GlobalMemoryStatusEx(&memInfo);
	DWORDLONG totalVirtualMem = memInfo.ullTotalPageFile;
	return (double)totalVirtualMem;
}

//2. Занято виртуальной памяти.
extern "C" __declspec (dllexport) double _stdcall VirtualMemoryUsed()
{
	MEMORYSTATUSEX memInfo;
	memInfo.dwLength = sizeof(MEMORYSTATUSEX);
	GlobalMemoryStatusEx(&memInfo);
	DWORDLONG totalVirtualMem = memInfo.ullTotalPageFile - memInfo.ullAvailPageFile;
	return (double)totalVirtualMem;
}

//3. Общее кол-во оперативной памяти.
extern "C" __declspec (dllexport) double _stdcall PhysicalMemoryTotal()
{
	MEMORYSTATUSEX memInfo;
	memInfo.dwLength = sizeof(MEMORYSTATUSEX);
	GlobalMemoryStatusEx(&memInfo);
	DWORDLONG totalPhysMem = memInfo.ullTotalPhys;
	return (double)totalPhysMem;
}

//4. Занято оперативной памяти
extern "C" __declspec (dllexport) double _stdcall PhysicalMemoryUsed()
{
	MEMORYSTATUSEX memInfo;
	memInfo.dwLength = sizeof(MEMORYSTATUSEX);
	GlobalMemoryStatusEx(&memInfo);
	DWORDLONG physMemUsed = memInfo.ullTotalPhys - memInfo.ullAvailPhys;
	//return CPUUsed();
	return (double)physMemUsed;
}

//5. Загрузка процессора
extern "C" __declspec (dllexport) double _stdcall CPUUsed()
{
	typedef NTSTATUS(NTAPI* pfNtQuerySystemInformation) (
		IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
		OUT PVOID SystemInformation,
		IN ULONG SystemInformationLength,
		OUT PULONG ReturnLength OPTIONAL
		);

	static pfNtQuerySystemInformation NtQuerySystemInformation = NULL;

	if (NtQuerySystemInformation == NULL)
	{
		//HMODULE ntDLL = ::GetModuleHandle("ntdll.dll");
		HMODULE ntDLL = GetModuleHandle(TEXT("ntdll.dll"));
		NtQuerySystemInformation = (pfNtQuerySystemInformation)GetProcAddress(ntDLL, "NtQuerySystemInformation");
	}

	static SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION lastInfo = { 0 };
	SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION curInfo = { 0 };

	ULONG retsize;

	NtQuerySystemInformation(SystemProcessorPerformanceInformation, &curInfo, sizeof(curInfo), &retsize);

	double cpuUsage = -1;

	if (lastInfo.KernelTime.QuadPart != 0 || lastInfo.UserTime.QuadPart != 0)
		cpuUsage = 100.0 - double(curInfo.IdleTime.QuadPart - lastInfo.IdleTime.QuadPart) /
		double(curInfo.KernelTime.QuadPart - lastInfo.KernelTime.QuadPart + curInfo.UserTime.QuadPart - lastInfo.UserTime.QuadPart) * 100.0;

	lastInfo = curInfo;

	return cpuUsage;
}


/*extern "C" __declspec (dllexport) double _stdcall CPUUsed()
{
	PDH_HQUERY cpuQuery;
	PDH_HCOUNTER cpuTotal;
	PdhOpenQuery(NULL, NULL, &cpuQuery);
	PdhAddCounter(cpuQuery, L"\\Processor(_Total)\\% Processor Time", NULL, &cpuTotal);
	PdhCollectQueryData(cpuQuery);
	PDH_FMT_COUNTERVALUE counterVal;
	PdhCollectQueryData(cpuQuery);
	PdhGetFormattedCounterValue(cpuTotal, PDH_FMT_DOUBLE, NULL, &counterVal);
	return counterVal.doubleValue;
}*/





