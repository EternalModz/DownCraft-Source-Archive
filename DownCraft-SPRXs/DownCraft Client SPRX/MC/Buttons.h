namespace Buttons
{
	unsigned int buttonMonitoring = 0x3000CF79; //Address Buttons 1.84
	unsigned int

		X = 0x100,
		O = 0x200,
		SQUARE = 0x400,
		TRIANGLE = 0x800,
		UP = 0x40000,
		DOWN = 0x80000,
		LEFT = 0x100000,
		RIGHT = 0x200000,
		R1 = 0x4000,
		R2 = 0x0, //NEED FOUND
		R3 = 0x10000,
		L1 = 0x8000,
		L2 = 0x0, //NEED FOUND
		L3 = 0x20000,
		START = 0x2000,
		SELECT = 0x1000
		;

	unsigned int getMCButtons()
	{
		return *(unsigned int*)(buttonMonitoring);
	}

	bool IsMCButtonPressed(unsigned int Buttons)
	{
		return (getMCButtons() & Buttons) > 0;
	}
}