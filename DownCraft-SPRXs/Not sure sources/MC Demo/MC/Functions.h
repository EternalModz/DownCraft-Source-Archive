
enum Offsets
{
	IsInWorld = 0x3000CF6B,
	NameChanger = 0x3000ABE4,
};

bool InWorld()
{
	return !(*(char*)IsInWorld != 0);
}

void Option(uint Offset, const void* HEX)
{
	write_process(Offset, &HEX, sizeof(HEX));
}

void DrawText(uint Offset, char* Text)
{
	strcpy((char*)Offset, Text);
}

void DrawBackground(float Width, float Height, float X, float Y, float R, float G, float B, float A)
{

}


void DrawText()
{
	DrawText(0x320E89E0, "DownCraft SPRX");
}
