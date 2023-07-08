#include "sys/return_code.h"

uint32_t GetCurrentToc()
{
	uint32_t* entry_point = *reinterpret_cast<uint32_t**>(0x1001C); // ElfHeader->e_entry 
	return entry_point[1];
}

uint32_t sys_dbg_write_process_memory(uint32_t pid, void* address, const void* data, size_t size)
{
	system_call_4(905, (uint64_t)pid, (uint64_t)address, (uint64_t)size, (uint64_t)data);
	return_to_user_prog(uint32_t);
}

uint32_t sys_hen_write_process_memory(uint32_t pid, void* address, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)pid, (uint64_t)address, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(uint32_t);
}

uint32_t WriteProcessMemory(uint32_t pid, void* address, const void* data, size_t size)
{
	static bool useHenSyscalls = false;

	if (!useHenSyscalls)
	{
		uint32_t write = sys_dbg_write_process_memory(pid, address, data, size);
		if (write == SUCCEEDED)
		{
			return write;
		}
	}

	useHenSyscalls = true;
	return sys_hen_write_process_memory(pid, address, data, size);
}
struct opd_s
{
	uint32_t func;
	uint32_t toc;
};

struct importStub_s
{
	int16_t ssize;
	int16_t header1;
	int16_t header2;
	int16_t imports;
	int32_t zero1;
	int32_t zero2;
	const char* name;
	uint32_t* fnid;
	opd_s** stub;
	int32_t zero3;
	int32_t zero4;
	int32_t zero5;
	int32_t zero6;
};

struct exportStub_s
{
	int16_t ssize;
	int16_t header1;
	int16_t header2;
	int16_t exports; // number of exports
	int32_t zero1;
	int32_t zero2;
	const char* name;
	uint32_t* fnid;
	opd_s** stub;
};

uint32_t GetCurrentToc();

uint32_t sys_dbg_write_process_memory(uint32_t pid, void* address, const void* data, size_t size);

uint32_t sys_hen_write_process_memory(uint32_t pid, void* address, const void* data, size_t size);

//uint32_t WriteProcessMemory(uint32_t pid, void* address, const void* data, size_t size);

/*template <typename R, typename... TArgs>
__ALWAYS_INLINE R GameCall(std::uint32_t addr, TArgs... args)
{
volatile opd_s opd = { addr, GetCurrentToc() };
R(*func)(TArgs...) = (R(*)(TArgs...)) & opd;
return func(args...);
}*/