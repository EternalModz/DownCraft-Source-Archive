/*This is what i converted from my Minecraft Mod Tool. If you know how to find everything to C++, then you will be able to figure out what 
to do. I wrote out what i thought would work but so far im stick on it naming the menu and scroller. Feel free to use this to find what you
need. I did my best and im to the point of almost giving up. */

using namespace PS3Lib;

namespace Connect_Tool
{

	unsigned int _L2, _R2, R1, R2, R3, L1, L2, L3, DpadUp, DpadDown, DpadLeft, DpadRight, Cross, Square, Circle, Triangle, Select, Form1::MCbuttonsOffsets::Start = 0xB3;
	unsigned char R1, R2, R3, L1, L2, L3, DpadUp, DpadDown, DpadLeft, DpadRight, Cross, Square, Circle, Triangle, Select, Form1::MCbuttonsBytes::Start = 0x10;
	unsigned int Form1::ProcessID = 0;

	Form1::Form1()
	{
		InitializeInstanceFields();
		InitializeComponent();
	}

	void Form1::button1_Click(void *sender, EventArgs *e)
	{
		if (PS3->ConnectTarget())
		{
			if (PS3->AttachProcess())
			{
				setText(L"You Have Connected to Dublin Modz Minecraft RTM Tool Hope You Enjoy");
			}
			else
			{
				setText(L"Tool Cannot Attach");
			}
		}
		else
		{
			setText(L"Tool Cannot Connect");
		}
	}

	void Form1::Form1_Load(void *sender, EventArgs *e)
	{

	}

	void Form1::Button2_Click(void *sender, EventArgs *e)
	{
		unsigned char InfinatePickUp[1] = { 0x00 };
		this->PS3->SetMemory(0x1EA47F, InfinatePickUp);
		MessageBox::Show(L"Infinant Pick-Up is Now on");
	}

	void Form1::CheckBox1_CheckedChanged(void *sender, EventArgs *e)
	{
		if (CheckBox1->Checked == true)
		{
			PS3->SetMemory(0x1EA47F, new unsigned char[] {0x00});
			setText(L"Infinant Pick Up Is On");
		}
		else
		{
			PS3->SetMemory(0x1EA47F, new unsigned char[] {0x01});
			setText(L"Infinant Pick Up Is Off");
		}

	}

	std::vector<unsigned int> Form1::ins = std::vector<unsigned int>();

	void Form1::button3_Click(void *sender, EventArgs *e)
	{
		unsigned char InfinatePickUp[1] = { 0x01 };
		this->PS3->SetMemory(0x1EA47F, InfinatePickUp);
		MessageBox::Show(L"Infinant Pick-Up is Now off");
	}

	void Form1::DRAW_RECT(unsigned int ofs, unsigned int width, unsigned int strechV, unsigned int stretchH, unsigned int height, unsigned int xPos, unsigned int yPos)
	{
		PS3->getExtension()->WriteUInt32(ofs, width); //Width
		PS3->getExtension()->WriteUInt32(ofs + 0x04, strechV); //Strech Vertical
		PS3->getExtension()->WriteUInt32(ofs + 0x08, stretchH); //Strech horizontal
		PS3->getExtension()->WriteUInt32(ofs + 0x0C, height); //Height
		PS3->getExtension()->WriteUInt32(ofs + 0x10, xPos); //X Pos
		PS3->getExtension()->WriteUInt32(ofs + 0x14, yPos); //Y Pos
	}

	std::wstring Form1::fixText(const std::wstring &fixStr)
	{
		int getPos = fixStr.length();
		int place = 1;
		for (int i = 0; i < getPos; i++)
		{
			fixStr.insert(place, L".");
			place += 2;
		}
		//C# TO C++ CONVERTER TODO TASK: There is no direct native C++ equivalent to this .NET String method:
		fixStr = fixStr.Replace(L".", L"\0");
		return fixStr + std::wstring(L"\0\0");
	}

	void Form1::button4_Click(void *sender, EventArgs *e)
	{
		// if number is below 40, put C0 and then count up and visversa

		//Edit Text : Hold start to update text


	}

	void Form1::button5_Click(void *sender, EventArgs *e)
	{

	}

	unsigned int Form1::getOfs(int num)
	{
		return Form1::ins[num];
	}

	unsigned int Form1::_getOfs(unsigned int num)
	{
		return num;
	}

	void Form1::PS3api()
	{
		if (PS3->GetCurrentAPIName() == L"Target Manager")
		{
			PS3->ConnectTarget();
		}
		else if (PS3->GetCurrentAPIName() == L"Control Console")
		{
			PS3->ConnectTarget();
		}
	}

	bool Form1::canUse()
	{
		if (PS3->getExtension()->ReadByte(memRegion + 0x3000cf68) == 0x00)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	unsigned int Form1::getRegion()
	{
		unsigned char check[4] = { 0xFF, 0xFF, 0xFF, 0xFF };
		if (PS3->getExtension()->ReadBytes(0x30000000 + 0x20, sizeof(check) / sizeof(check[0]))->SequenceEqual(check))
		{
			return 0;
		}
		else if (PS3->getExtension()->ReadBytes(0x30000000 + 0x20 + 0x10000000, sizeof(check) / sizeof(check[0]))->SequenceEqual(check))
		{
			return 0x10000000;
		}
		else if (PS3->getExtension()->ReadBytes(0x30000000 + 0x20 + 0x20000000, sizeof(check) / sizeof(check[0]))->SequenceEqual(check))
		{
			return 0x20000000;
		}
		else if (PS3->getExtension()->ReadBytes(0x30000000 + 0x20 + 0x30000000, sizeof(check) / sizeof(check[0]))->SequenceEqual(check))
		{
			return 0x30000000;
		}
		else
		{
			return 0;
		}
	}

	void Form1::runBinds()
	{

	}

	void Form1::checkedListBox1_SelectedIndexChanged(void *sender, EventArgs *e)
	{

	}

	void Form1::checkedListBox2_SelectedIndexChanged(void *sender, EventArgs *e)
	{

	}

	void Form1::checkBox2_CheckedChanged(void *sender, EventArgs *e)
	{

	}

	void Form1::CheckBox2_CheckedChanged_1(void *sender, EventArgs *e)
	{
		if (checkBox2->Checked == true)
		{
			PS3->SetMemory(0x004244A8, new unsigned char[2]{ 0xFC, 0x00 });
			setText(L"God Mode Is On");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"God Mode Is On");
		}
		else
		{
			PS3->SetMemory(0x004244A8, new unsigned char[2]{ 0xFC, 0x20 });
			setText(L"God Mode Is Off");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"God Mode Is Off");
		}
	}

	void Form1::button6_Click(void *sender, EventArgs *e)
	{
		try
		{
			PS3->ConnectTarget(0);
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Successfully Connected To PS3, ENJOY DUBLIN MODZ Minecraft TOOL");
			setText(L"Connected");
		}
		catch (...)
		{
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Failed To Connect");
		}
	}

	void Form1::button7_Click(void *sender, EventArgs *e)
	{
		PS3->AttachProcess();
		{

			MessageBox::Show(L"Current game is attached successfully.", L"Success.", MessageBoxButtons::OK, MessageBoxIcon::Asterisk);
			setText(L"Attached!");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Successfully Attached To Tool, Welcome to DUBLIN MODZ RTM TOOL, Have Fun!");
			memRegion = getRegion();
			if (!backgroundWorker1->IsBusy)
			{
				backgroundWorker1->RunWorkerAsync();
			}

		}
	}

	void Form1::radioButton1_CheckedChanged(void *sender, EventArgs *e)
	{
		PS3->ChangeAPI(SelectAPI::ControlConsole);
	}

	void Form1::checkBox3_CheckedChanged(void *sender, EventArgs *e)
	{
		if (checkBox3->Checked == true)
		{
			PS3->SetMemory(0x00328375, new unsigned char[] {0x80});
			setText(L"No Fall Damage Is On");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"No Fall Damage Is On!");
		}
		else
		{
			PS3->SetMemory(0x00328375, new unsigned char[] {0x20});
			setText(L"No Fall Damage Is Off");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"No Fall Damage Is Off");
		}
	}

	void Form1::checkBox4_CheckedChanged(void *sender, EventArgs *e)
	{
		if (checkBox4->Checked == true)
		{
			PS3->SetMemory(0x00422C89, new unsigned char[] {0x80});
			setText(L"Change View Is On");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Change View Is On");
		}
		else
		{
			PS3->SetMemory(0x00422C89, new unsigned char[] {0x20});
			setText(L"Change View Is Off");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Change View Is Off");
		}
	}

	void Form1::checkBox5_CheckedChanged(void *sender, EventArgs *e)
	{
		if (checkBox5->Checked == true)
		{
			PS3->SetMemory(0x00342ABC, new unsigned char[2]{ 0x3F, 0xA0 });
			setText(L"Brighteness is set to high");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Brighteness is set to high");
		}
		else
		{
			PS3->SetMemory(0x00342ABC, new unsigned char[2]{ 0x3F, 0x00 });
			setText(L"Brighteness is set to Normal");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Brightness Is Set To Normal");
		}
	}

	void Form1::checkBox6_CheckedChanged(void *sender, EventArgs *e)
	{
		if (checkBox6->Checked == true)
		{
			PS3->SetMemory(0x002D4AFC, new unsigned char[] {0x30});
			setText(L"Disable Mining is On");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Disable Mining is On");
		}
		else
		{
			PS3->SetMemory(0x002D4AFC, new unsigned char[] {0x3F});
			setText(L"Disable Minging Is Off");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"Disable Mining is Off");
		}
	}

	void Form1::checkBox7_CheckedChanged(void *sender, EventArgs *e)
	{

	}

	void Form1::button1_Click_1(void *sender, EventArgs *e)
	{
		if (button1->Text == L"Start")
		{
			subOpts = richTextBox1->Lines;
			openMenu();
			setMenuTxt(1);
			button1->Text = L"Stop";
			menuRunning = true;
		}
		else if (button1->Text == L"Stop")
		{
			stopMenu();
			closeMenu();
		}
	}

	void Form1::stopMenu()
	{
		button1->Text = L"Start";
		closeMenu();
		setMenuTxt(0);
		menuRunning = false;
		scrollPos = 1;
		curSub = 0;
		maxSub = sizeof(mainPos) / sizeof(mainPos[0]);
		linePos = mainPos;
		checkBox6->Enabled = true;
	}

	int Form1::mainPos[4] = { -16104, -16320, -16527, -16749 };

	std::wstring Form1::hexColor(Color cRGB)
	{
		unsigned int index = 0x3D00;
		double interval = 3.0117;
		double hexR = cRGB.R * interval + index;
		double hexG = cRGB.G * interval + index;
		double hexB = cRGB.B * interval + index;
		double hexA = cRGB.A * interval + index;
		std::wstring getHexR = std::wstring::Format(L"{0:X}", static_cast<unsigned int>(hexR));
		std::wstring getHexG = std::wstring::Format(L"{0:X}", static_cast<unsigned int>(hexG));
		std::wstring getHexB = std::wstring::Format(L"{0:X}", static_cast<unsigned int>(hexB));
		return getHexR + std::wstring(L"0000") + getHexG + std::wstring(L"0000") + getHexB;
	}

	void Form1::openMenu()
	{
		for (int i = 0; i < forceUse; i++)
		{
			PS3->SetMemory(0x01483C14, new unsigned char[] {0x01});
		}
		Task::Delay(hudDelay).Wait();
		showHud();
		scrollOpt(scrollPos);
		isOpen = true;
	}

	void Form1::closeMenu()
	{
		isOpen = false;
		hideHud();
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			PS3->SetMemory(0x01483C14, new unsigned char[] {0x00});
		}
	}

	void Form1::showHud()
	{
		if (useInBattle)
		{
			txtOfs = 0x3118F54C;
			txtBgOfs = 0x3118EA9C;
		}
		else
		{
			txtOfs = 0x311914CC;
			txtBgOfs = 0x31190A1C;
		}
		for (int i = 0; i < forceUse; i++)
		{
			setHud(memRegion + txtOfs, 0x3FA00000, 0x00000000, 0x00000000, 0x3FE00000, 0x53000000, 0xC3C90000);
			if (!useInBattle)
			{
				setHud(memRegion + 0x3118F54C, 0x3F800000, 0x00000000, 0x00000000, 0x30000000, 0x00000000, 0x00000000);
			}
		}
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			if (!useInBattle)
			{
				PS3->SetMemory(memRegion + 0x3118EA9C + 0x44, ConvertHexToBytes(hexColor(themeC)));
				PS3->SetMemory(memRegion + 0x31190A1C + 0x44, ConvertHexToBytes(hexColor(tintColor(themeC))));
			}
			else
			{
				PS3->SetMemory(memRegion + txtBgOfs + 0x44, ConvertHexToBytes(L"3000000030000000300000004F000000"));
			}
		}
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			unsigned int pos = 0x440C0000;
			if (!useInBattle)
			{
				pos = 0x43CC0000;
				setHud(memRegion + 0x3118EA9C, 0x45000000, 0x00000000, 0x00000000, 0x40300000, 0xC4000000, 0xC3D00000);
			}
			setHud(memRegion + txtBgOfs, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, pos, 0xC3C30000);
		}
	}

	void Form1::hideHud()
	{
		if (useInBattle)
		{
			txtOfs = 0x3118F54C;
		}
		else
		{
			txtOfs = 0x311914CC;
		}
		for (int i = 0; i < forceUse; i++)
		{
			setHud(memRegion + txtOfs, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000);
			if (!useInBattle)
			{
				setHud(memRegion + 0x3118F54C, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000);
			}
		}
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			setHud(memRegion + 0x3118EA9C, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000);
			setHud(memRegion + 0x31190A1C, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000);
		}
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			PS3->SetMemory(memRegion + 0x3118EA9C + 0x44, ConvertHexToBytes(L"3F8000003F8000003F8000003F800000"));
			PS3->SetMemory(memRegion + 0x31190A1C + 0x44, ConvertHexToBytes(L"3F8000003F8000003F8000003F800000"));
		}
	}

	unsigned char *Form1::ConvertHexToBytes(const std::wstring &input)
	{
		auto result = new unsigned char[(input.length() + 1) / 2];
		auto offset = 0;
		if (input.length() % 2 == 1)
		{
			result[0] = static_cast<unsigned char>(Convert::ToUInt32(input[0] + std::wstring(L""), 16));
			offset = 1;
		}
		for (int i = 0; i < input.length() / 2; i++)
		{
			result[i + offset] = static_cast<unsigned char>(Convert::ToUInt32(input.substr(i * 2 + offset, 2), 16));
		}
		return result;
	}

	void Form1::setMenuTxt(int num)
	{
		if (useInBattle)
		{
			menuId = 0x302bfdc8;
		}
		else
		{
			menuId = 0x302bf5e8;
		}
		if (num == 1)
		{
			for (int i = 0; i < forceUse; i++)
			{
				PS3->getExtension()->WriteUInt32(memRegion + menuId, memRegion + 0x310a1337 - 1);
			}
			std::wstring space = L"   ";
			std::wstring txt = L"Crafting";
			std::wstring addNum = addSpace(110);
			if (useInBattle)
			{
				txt = L"Inventory";
				addNum = addSpace(120);
			}
			std::wstring txtLine = txt + addNum + std::wstring::Join(space, subOpts);
			Task::Delay(hudDelay).Wait();
			for (int i = 0; i < forceUse; i++)
			{
				PS3->SetMemory(memRegion + 0x310a1337, Encoding::ASCII->GetBytes(fixText(txtLine)));
			}
		}
		else if (num == 0)
		{
			for (int i = 0; i < forceUse; i++)
			{
				PS3->getExtension()->WriteUInt32(memRegion + menuId, memRegion + menuId + 0x28);
			}
		}
	}

	void Form1::closeSub()
	{
		if (curSub == 0)
		{
			closeMenu();
		}
		else
		{
			linePos = mainPos;
			maxSub = linePos->Length;
			scrollPos = curSub;
			curSub = 0;
			scrollOpt(scrollPos);
		}
	}

	void Form1::scrollOpt(int pos)
	{
		if (useInBattle)
		{
			txtOfs = 0x3118F54C;
		}
		else
		{
			txtOfs = 0x311914CC;
		}
		scrollPos = doScroll(pos, maxSub);
		for (int i = 0; i < forceUse; i++)
		{
			setHud(memRegion + txtOfs, linePos[scrollPos - 1] + -1689);
		}
		Task::Delay(200).Wait();
	}

	void Form1::setHud(unsigned int ofs, unsigned int width, unsigned int strechV, unsigned int stretchH, unsigned int height, unsigned int xPos, unsigned int yPos)
	{
		std::vector<unsigned char> buffer = std::vector<unsigned char>();
		//C# TO C++ CONVERTER WARNING: Since the array size is not known in this declaration, C# to C++ Converter has converted this array to a pointer.  You will need to call 'delete[]' where appropriate:
		//ORIGINAL LINE: byte[] rev = BitConverter.GetBytes(width);
		unsigned char *rev = BitConverter::GetBytes(width);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		rev = BitConverter::GetBytes(strechV);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		rev = BitConverter::GetBytes(stretchH);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		rev = BitConverter::GetBytes(height);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		rev = BitConverter::GetBytes(xPos);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		rev = BitConverter::GetBytes(yPos);
		Array::Reverse(rev);
		buffer.AddRange(rev);
		PS3->SetMemory(ofs, buffer.ToArray());
	}

	void Form1::setHud(unsigned int ofs, float xPos)
	{
		PS3->getExtension()->WriteFloat(ofs + 0x10, xPos);
	}

	std::wstring Form1::addSpace(int num)
	{
		std::wstring space = L"";
		for (int i = 0; i < num; i++)
		{
			space += std::wstring(L" ");
		}
		return space;
	}

	int Form1::doScroll(int scroll, int max)
	{
		scroll = scrollPos;
		if (scroll == max + 1)
		{
			return 1;
		}
		else if (scroll == 0)
		{
			return max;
		}
		else
		{
			return scroll;
		}
	}

	Color Form1::tintColor(Color rgb)
	{
		try
		{
			int cR[3];
			int num[3];
			for (int i = 0; i < 3; i++)
			{
				if (i == 0)
				{
					cR[i] = rgb.R;
				}
				if (i == 1)
				{
					cR[i] = rgb.G;
				}
				if (i == 2)
				{
					cR[i] = rgb.B;
				}
				if (cR[i] > 51)
				{
					num[i] = 50;
				}
				else
				{
					num[i] = cR[i];
				}
			}
			return Color::FromArgb(255, cR[0] - num[0], cR[1] - num[1], cR[2] - num[2]);
		}
		catch (...)
		{
			return Color::White;
		}
	}

	void Form1::selectOpt()
	{

		Task::Delay(200).Wait();
	}

	bool Form1::MCbuttonPressed(unsigned int MCoffset, unsigned char Mcbyte)
	{
		if (PS3->getExtension()->ReadByte(memRegion + 0x3000cec8 + MCoffset) == Mcbyte)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool Form1::MCbuttonPressed(unsigned int MCoffset)
	{
		if (PS3->getExtension()->ReadByte(memRegion + 0x3000cec8 + MCoffset) > 0x00)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void Form1::runMenu()
	{
		if (menuRunning)
		{
			if (isOpen)
			{
				if (!canUse())
				{
					closeMenu();
				}
				if (MCbuttonPressed(MCbuttonsOffsets::DpadLeft, MCbuttonsBytes::DpadLeft))
				{
					scrollOpt(scrollPos--);
				}
				else if (MCbuttonPressed(MCbuttonsOffsets::DpadRight, MCbuttonsBytes::DpadRight))
				{
					scrollOpt(scrollPos++);
				}
				else if (MCbuttonPressed(MCbuttonsOffsets::Square, MCbuttonsBytes::Square))
				{
					selectOpt();
				}
				else if (MCbuttonPressed(MCbuttonsOffsets::Circle, MCbuttonsBytes::Circle))
				{
					closeSub();
				}
			}
			else
			{
				if (MCbuttonPressed(MCbuttonsOffsets::DpadUp, MCbuttonsBytes::DpadUp) && canUse())
				{
					openMenu();
				}
			}
		}
	}

	void Form1::backgroundWorker1_DoWork(void *sender, DoWorkEventArgs *e)
	{
		PS3api();
		for (; ;)
		{
			runMenu();
		}
	}

	void Form1::checkBox8_CheckedChanged(void *sender, EventArgs *e)
	{
		if (checkBox8->Checked == true)
		{
			PS3->SetMemory(0x00422F49, new unsigned char[] {0x80});
			setText(L"God Mode Is On");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"God Mode Is On");
		}
		else
		{
			PS3->SetMemory(0x00422F49, new unsigned char[] {0x20});
			setText(L"God Mode Is Off");
			PS3->getCCAPI()->Notify(CCAPI::NotifyIcon::INFO, L"God Mode Is Off");
		}
	}

	void Form1::Dispose(bool disposing)
	{
		if (disposing && (components != nullptr))
		{
			delete components;
		}
		//C# TO C++ CONVERTER NOTE: There is no explicit call to the base class destructor in C++:
		//		base.Dispose(disposing);
	}

	void Form1::InitializeComponent()
	{
		this->button2 = new System::Windows::Forms::Button();
		this->CheckBox1 = new System::Windows::Forms::CheckBox();
		this->button3 = new System::Windows::Forms::Button();
		this->button4 = new System::Windows::Forms::Button();
		this->button5 = new System::Windows::Forms::Button();
		this->checkedListBox1 = new System::Windows::Forms::CheckedListBox();
		this->checkedListBox2 = new System::Windows::Forms::CheckedListBox();
		this->checkBox2 = new System::Windows::Forms::CheckBox();
		this->button6 = new System::Windows::Forms::Button();
		this->button7 = new System::Windows::Forms::Button();
		this->radioButton1 = new System::Windows::Forms::RadioButton();
		this->checkBox3 = new System::Windows::Forms::CheckBox();
		this->checkBox4 = new System::Windows::Forms::CheckBox();
		this->checkBox5 = new System::Windows::Forms::CheckBox();
		this->checkBox6 = new System::Windows::Forms::CheckBox();
		this->checkBox7 = new System::Windows::Forms::CheckBox();
		this->button1 = new System::Windows::Forms::Button();
		this->backgroundWorker1 = new System::ComponentModel::BackgroundWorker();
		this->richTextBox1 = new System::Windows::Forms::RichTextBox();
		this->checkBox8 = new System::Windows::Forms::CheckBox();
		this->SuspendLayout();
		// 
		// button2
		// 
		this->button2->Location = System::Drawing::Point(0, 191);
		this->button2->Name = L"button2";
		this->button2->Size = System::Drawing::Size(206, 48);
		this->button2->TabIndex = 1;
		this->button2->TabStop = false;
		this->button2->Text = L"Unlimited Pickup";
		this->button2->UseVisualStyleBackColor = true;
		this->button2->Click += new System::EventHandler(this, &Form1::Button2_Click);
		// 
		// CheckBox1
		// 
		this->CheckBox1->AutoSize = true;
		this->CheckBox1->Location = System::Drawing::Point(252, 13);
		this->CheckBox1->Name = L"CheckBox1";
		this->CheckBox1->Size = System::Drawing::Size(102, 17);
		this->CheckBox1->TabIndex = 2;
		this->CheckBox1->Text = L"Infinant Pick-Up";
		this->CheckBox1->UseVisualStyleBackColor = true;
		this->CheckBox1->CheckedChanged += new System::EventHandler(this, &Form1::CheckBox1_CheckedChanged);
		// 
		// button3
		// 
		this->button3->Location = System::Drawing::Point(0, 245);
		this->button3->Name = L"button3";
		this->button3->Size = System::Drawing::Size(206, 48);
		this->button3->TabIndex = 3;
		this->button3->TabStop = false;
		this->button3->Text = L"Unlimited Pickup Off";
		this->button3->UseVisualStyleBackColor = true;
		this->button3->Click += new System::EventHandler(this, &Form1::button3_Click);
		// 
		// button4
		// 
		this->button4->Location = System::Drawing::Point(212, 299);
		this->button4->Name = L"button4";
		this->button4->Size = System::Drawing::Size(206, 48);
		this->button4->TabIndex = 4;
		this->button4->TabStop = false;
		this->button4->Text = L"Test on";
		this->button4->UseVisualStyleBackColor = true;
		this->button4->Click += new System::EventHandler(this, &Form1::button4_Click);
		// 
		// button5
		// 
		this->button5->Location = System::Drawing::Point(0, 299);
		this->button5->Name = L"button5";
		this->button5->Size = System::Drawing::Size(206, 48);
		this->button5->TabIndex = 5;
		this->button5->TabStop = false;
		this->button5->Text = L"Test off";
		this->button5->UseVisualStyleBackColor = true;
		this->button5->Click += new System::EventHandler(this, &Form1::button5_Click);
		// 
		// checkedListBox1
		// 
		this->checkedListBox1->FormattingEnabled = true;
		this->checkedListBox1->Items->AddRange(new Object[5]{ L"host1", L"host2", L"host3", L"host4", L"host5" });
		this->checkedListBox1->Location = System::Drawing::Point(574, 140);
		this->checkedListBox1->Name = L"checkedListBox1";
		this->checkedListBox1->Size = System::Drawing::Size(184, 139);
		this->checkedListBox1->TabIndex = 6;
		this->checkedListBox1->SelectedIndexChanged += new System::EventHandler(this, &Form1::checkedListBox1_SelectedIndexChanged);
		// 
		// checkedListBox2
		// 
		this->checkedListBox2->FormattingEnabled = true;
		this->checkedListBox2->Items->AddRange(new Object[5]{ L"host1", L"host2", L"host3", L"host4", L"host5" });
		this->checkedListBox2->Location = System::Drawing::Point(384, 140);
		this->checkedListBox2->Name = L"checkedListBox2";
		this->checkedListBox2->Size = System::Drawing::Size(184, 139);
		this->checkedListBox2->TabIndex = 7;
		this->checkedListBox2->SelectedIndexChanged += new System::EventHandler(this, &Form1::checkedListBox2_SelectedIndexChanged);
		// 
		// checkBox2
		// 
		this->checkBox2->AutoSize = true;
		this->checkBox2->Location = System::Drawing::Point(252, 36);
		this->checkBox2->Name = L"checkBox2";
		this->checkBox2->Size = System::Drawing::Size(76, 17);
		this->checkBox2->TabIndex = 8;
		this->checkBox2->Text = L"God Mode";
		this->checkBox2->UseVisualStyleBackColor = true;
		this->checkBox2->CheckedChanged += new System::EventHandler(this, &Form1::CheckBox2_CheckedChanged_1);
		// 
		// button6
		// 
		this->button6->Location = System::Drawing::Point(0, 68);
		this->button6->Name = L"button6";
		this->button6->Size = System::Drawing::Size(206, 48);
		this->button6->TabIndex = 9;
		this->button6->TabStop = false;
		this->button6->Text = L"Connect";
		this->button6->UseVisualStyleBackColor = true;
		this->button6->Click += new System::EventHandler(this, &Form1::button6_Click);
		// 
		// button7
		// 
		this->button7->Location = System::Drawing::Point(0, 122);
		this->button7->Name = L"button7";
		this->button7->Size = System::Drawing::Size(206, 48);
		this->button7->TabIndex = 10;
		this->button7->TabStop = false;
		this->button7->Text = L"Attach";
		this->button7->UseVisualStyleBackColor = true;
		this->button7->Click += new System::EventHandler(this, &Form1::button7_Click);
		// 
		// radioButton1
		// 
		this->radioButton1->AutoSize = true;
		this->radioButton1->Location = System::Drawing::Point(446, 12);
		this->radioButton1->Name = L"radioButton1";
		this->radioButton1->Size = System::Drawing::Size(85, 17);
		this->radioButton1->TabIndex = 11;
		this->radioButton1->TabStop = true;
		this->radioButton1->Text = L"radioButton1";
		this->radioButton1->UseVisualStyleBackColor = true;
		this->radioButton1->CheckedChanged += new System::EventHandler(this, &Form1::radioButton1_CheckedChanged);
		// 
		// checkBox3
		// 
		this->checkBox3->AutoSize = true;
		this->checkBox3->Location = System::Drawing::Point(252, 59);
		this->checkBox3->Name = L"checkBox3";
		this->checkBox3->Size = System::Drawing::Size(102, 17);
		this->checkBox3->TabIndex = 12;
		this->checkBox3->Text = L"No Fall Damage";
		this->checkBox3->UseVisualStyleBackColor = true;
		this->checkBox3->CheckedChanged += new System::EventHandler(this, &Form1::checkBox3_CheckedChanged);
		// 
		// checkBox4
		// 
		this->checkBox4->AutoSize = true;
		this->checkBox4->Location = System::Drawing::Point(252, 82);
		this->checkBox4->Name = L"checkBox4";
		this->checkBox4->Size = System::Drawing::Size(89, 17);
		this->checkBox4->TabIndex = 13;
		this->checkBox4->Text = L"Change View";
		this->checkBox4->UseVisualStyleBackColor = true;
		this->checkBox4->CheckedChanged += new System::EventHandler(this, &Form1::checkBox4_CheckedChanged);
		// 
		// checkBox5
		// 
		this->checkBox5->AutoSize = true;
		this->checkBox5->Location = System::Drawing::Point(252, 105);
		this->checkBox5->Name = L"checkBox5";
		this->checkBox5->Size = System::Drawing::Size(115, 17);
		this->checkBox5->TabIndex = 14;
		this->checkBox5->Text = L"Change Brightness";
		this->checkBox5->UseVisualStyleBackColor = true;
		this->checkBox5->CheckedChanged += new System::EventHandler(this, &Form1::checkBox5_CheckedChanged);
		// 
		// checkBox6
		// 
		this->checkBox6->AutoSize = true;
		this->checkBox6->Location = System::Drawing::Point(252, 128);
		this->checkBox6->Name = L"checkBox6";
		this->checkBox6->Size = System::Drawing::Size(95, 17);
		this->checkBox6->TabIndex = 15;
		this->checkBox6->Text = L"Disable Mining";
		this->checkBox6->UseVisualStyleBackColor = true;
		this->checkBox6->CheckedChanged += new System::EventHandler(this, &Form1::checkBox6_CheckedChanged);
		// 
		// checkBox7
		// 
		this->checkBox7->AutoSize = true;
		this->checkBox7->Location = System::Drawing::Point(436, 299);
		this->checkBox7->Name = L"checkBox7";
		this->checkBox7->Size = System::Drawing::Size(117, 17);
		this->checkBox7->TabIndex = 16;
		this->checkBox7->Text = L"Enable Menu binds";
		this->checkBox7->UseVisualStyleBackColor = true;
		this->checkBox7->CheckedChanged += new System::EventHandler(this, &Form1::checkBox7_CheckedChanged);
		// 
		// button1
		// 
		this->button1->Location = System::Drawing::Point(585, 36);
		this->button1->Name = L"button1";
		this->button1->Size = System::Drawing::Size(206, 48);
		this->button1->TabIndex = 17;
		this->button1->TabStop = false;
		this->button1->Text = L"Start";
		this->button1->UseVisualStyleBackColor = true;
		this->button1->Click += new System::EventHandler(this, &Form1::button1_Click_1);
		// 
		// backgroundWorker1
		// 
		this->backgroundWorker1->DoWork += new System::ComponentModel::DoWorkEventHandler(this, &Form1::backgroundWorker1_DoWork);
		// 
		// richTextBox1
		// 
		this->richTextBox1->Location = System::Drawing::Point(782, 111);
		this->richTextBox1->Name = L"richTextBox1";
		this->richTextBox1->Size = System::Drawing::Size(157, 205);
		this->richTextBox1->TabIndex = 18;
		this->richTextBox1->Text = std::wstring(L"Infinite Pick-up\nGod Mode\nNo Fall Damage\nChange View\nChange Brightness\nDisable Mi") + std::wstring(L"ning");
		// 
		// checkBox8
		// 
		this->checkBox8->AutoSize = true;
		this->checkBox8->Location = System::Drawing::Point(252, 191);
		this->checkBox8->Name = L"checkBox8";
		this->checkBox8->Size = System::Drawing::Size(76, 17);
		this->checkBox8->TabIndex = 19;
		this->checkBox8->Text = L"God Mode";
		this->checkBox8->UseVisualStyleBackColor = true;
		this->checkBox8->CheckedChanged += new System::EventHandler(this, &Form1::checkBox8_CheckedChanged);
		// 
		// Form1
		// 
		this->setAutoScaleDimensions(System::Drawing::SizeF(6.0F, 13.0F));
		this->setAutoScaleMode(System::Windows::Forms::AutoScaleMode::Font);
		this->setClientSize(System::Drawing::Size(1043, 339));
		this->getControls()->Add(this->checkBox8);
		this->getControls()->Add(this->richTextBox1);
		this->getControls()->Add(this->button1);
		this->getControls()->Add(this->checkBox7);
		this->getControls()->Add(this->checkBox6);
		this->getControls()->Add(this->checkBox5);
		this->getControls()->Add(this->checkBox4);
		this->getControls()->Add(this->checkBox3);
		this->getControls()->Add(this->radioButton1);
		this->getControls()->Add(this->button7);
		this->getControls()->Add(this->button6);
		this->getControls()->Add(this->checkBox2);
		this->getControls()->Add(this->checkedListBox2);
		this->getControls()->Add(this->checkedListBox1);
		this->getControls()->Add(this->button5);
		this->getControls()->Add(this->button4);
		this->getControls()->Add(this->button3);
		this->getControls()->Add(this->CheckBox1);
		this->getControls()->Add(this->button2);
		this->setFormBorderStyle(System::Windows::Forms::FormBorderStyle::FixedToolWindow);
		this->setName(L"Form1");
		this->setText(L"w");
		this->Load += new System::EventHandler(this, &Form1::Form1_Load);
		this->ResumeLayout(false);
		this->PerformLayout();

	}

	void Form1::InitializeInstanceFields()
	{
		PS3 = new PS3API();
		rand = new Random();
		waitTime = 1000;
		std::wstring temp_mainTxt[4] = { L"Host Menu", L"Non-host Menu", L"Game Editor", L"Selector Color" };
		for (int element = 0; element < sizeof(temp_mainTxt) / sizeof(temp_mainTxt[0]); element++)
			mainTxt[element] = temp_mainTxt[element];
		std::wstring temp_editorTxt[6] = { L"Gravity", L"Speed", L"Surface Swim", L"Swim Speed", L"Exit Water", L"Vertical Swim" };
		for (int element = 0; element < sizeof(temp_editorTxt) / sizeof(temp_editorTxt[0]); element++)
			editorTxt[element] = temp_editorTxt[element];
		std::wstring temp_comboTxtnh[8] = { L"Wallhack", L"X-ray", L"Zoom", L"Rain Effect", L"Light Effect", L"Char Size", L"Time of Day", L"Vision" };
		for (int element = 0; element < sizeof(temp_comboTxtnh) / sizeof(temp_comboTxtnh[0]); element++)
			comboTxtnh[element] = temp_comboTxtnh[element];
		std::wstring temp_comboTxth[5] = { L"Mob Speed", L"Creeper Explo", L"Knockback", L"Xp Level", L"Health Level" };
		for (int element = 0; element < sizeof(temp_comboTxth) / sizeof(temp_comboTxth[0]); element++)
			comboTxth[element] = temp_comboTxth[element];
		useBinds = true;
		rgb_ = new ColorDialog();
		std::wstring *temp_subOpts = {};
		for (int element = 0; element < sizeof(temp_subOpts) / sizeof(temp_subOpts[0]); element++)
			subOpts[element] = temp_subOpts[element];
		menuId = 0;
		txtOfs = 0;
		txtBgOfs = 0;
		memRegion = 0;
		addOpt = std::vector<std::wstring>();
		forceUse = 1;
		useInBattle = false;
		hudDelay = 100;
		menuRunning = false;
		isOpen = false;
		scrollPos = 1;
		curSub = 0;
		maxSub = sizeof(mainPos) / sizeof(mainPos[0]);
		linePos = mainPos;
		themeC = Color::Red;
		int temp_sub1_1OptPos[17] = { 615, 407, 239, 11, -232, -466, -706, -886, -1120, -1390, -1597, -1822, -1975, -2284, -2539, -2776, -2998 };
		for (int element = 0; element < sizeof(temp_sub1_1OptPos) / sizeof(temp_sub1_1OptPos[0]); element++)
			sub1_1OptPos[element] = temp_sub1_1OptPos[element];
		int temp_sub1_2OptPos[6] = { -3944, -4229, -4412, -4595, -4790, -5021 };
		for (int element = 0; element < sizeof(temp_sub1_2OptPos) / sizeof(temp_sub1_2OptPos[0]); element++)
			sub1_2OptPos[element] = temp_sub1_2OptPos[element];
		int temp_sub2_1OptPos[29] = { -9888, -10113, -10221, -10419, -10590, -10758, -11085, -11229, -11427, -11610, -11760, -11949, -12192, -12384, -12492, -12654, -12876, -13059, -13314, -13524, -13665, -13875, -14070, -14253, -14421, -14625, -14751, -14952, -15210 };
		for (int element = 0; element < sizeof(temp_sub2_1OptPos) / sizeof(temp_sub2_1OptPos[0]); element++)
			sub2_1OptPos[element] = temp_sub2_1OptPos[element];
		int temp_sub2_2OptPos[18] = { -5920, -6061, -6187, -6400, -6589, -6766, -6976, -7129, -7255, -7366, -7531, -7684, -7852, -8050, -8329, -8500, -8710, -8986 };
		for (int element = 0; element < sizeof(temp_sub2_2OptPos) / sizeof(temp_sub2_2OptPos[0]); element++)
			sub2_2OptPos[element] = temp_sub2_2OptPos[element];
		components = 0;
	}
}
