#define TOC (0x17B84E8)
struct opd_s {int i,j;};
void sleep(usecond_t time) {sys_timer_usleep(time * 1000);}//1 second = 1000
int write_process(void* destination, const void* source, size_t size)
{
	system_call_4(905, (uint64_t)sys_process_getpid(), (uint64_t)destination, size, (uint64_t)source);//dex only
	return_to_user_prog(int);
}

int32_t _write_process(uint64_t ea, const void * data, uint32_t size)
{
	system_call_4(905, (uint64_t)sys_process_getpid(), ea, size, (uint64_t)data);
	return_to_user_prog(int32_t);
}

/*void PatchInJump(int Address, int Destination)
{
	int FuncBytes[4];
	Destination = *(int*)Destination;
	FuncBytes[0] = 0x3D600000 + ((Destination >> 16) & 0xFFFF);
	if (Destination & 0x8000) FuncBytes[0] += 1;
	FuncBytes[1] = 0x396B0000 + (Destination & 0xFFFF);
	FuncBytes[2] = 0x7D6903A6;
	FuncBytes[3] = 0x4E800420;
	write_process((void*)Address, FuncBytes, 4 * 4);
}*/

void PatchInJump(int Address, int Destination, bool Linked) 
{
	// use this data to copy over the address
	int FuncBytes[4];

	// Get the actual destination address
	Destination = *(int *)Destination;

	FuncBytes[0] = 0x3D600000 + ((Destination >> 16) & 0xFFFF); // lis     %r11, dest>>16
	if (Destination & 0x8000) // If bit 16 is 1
		FuncBytes[0] += 1;

		FuncBytes[1] = 0x396B0000 + (Destination & 0xFFFF); // addi    %r11, %r11, dest&0xFFFF
		FuncBytes[2] = 0x7D6903A6; // mtctr    %r11

		FuncBytes[3] = 0x4E800420; // bctr

		if (Linked)
			FuncBytes[3] += 1; // bctrl

		write_process((void*)Address, FuncBytes, 4 * 4);
}