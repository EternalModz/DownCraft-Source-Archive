#define OSK_TEXT_MAX 500
namespace NS_OSK
{
	enum eTextMode {
		closed,
		Open,
		JustClosed,
	};

	enum eCallBack {
		CustomName
	};

	int textMode = closed, saveId = 0; wchar_t* W_INIT_TEXT, * W_TITLE; char cText[OSK_TEXT_MAX];

	void OpenKeyboardNow(int id, wchar_t* title, wchar_t* text) {
		memset(ctime, 0, sizeof(cText)); W_TITLE = title; W_INIT_TEXT = text;
		saveId = id; Keyboard::oskdialog_mode = Keyboard::MODE_OPEN;
	}

	bool IsKeyboardOpen() {
		return (Keyboard::oskdialog_mode == Keyboard::MODE_OPEN) || (Keyboard::oskdialog_mode == Keyboard::MODE_RUNNING);
	}

	int GetSaveId() {
		return saveId;
	}

	const char* GetResult() {
		if (textMode == JustClosed) {
			textMode = closed;
			return cText;
		}
		else {
			return 0;
		}
	}

	void SetName(const char* name) {
		strcpy((char*)0x00000000, name);
	}

	void IskeyboardCallback() {
		const char* text = GetResult();
		if (text != 0)
		{
			switch (GetSaveId())
			{
			case eCallBack::CustomName:
				SetName(text); break;
			}
		}
	}

	int usleep(usecond_t time)
	{
		return sys_timer_usleep(time);
	}

	sys_ppu_thread_t create_osk_thread = SYS_PPU_THREAD_ID_INVALID;
	void osk_thread()
	{
		for (;;) {
			textMode = closed;
			while (IsKeyboardOpen()) {
				textMode = Open;
				Keyboard::keyboard(cText, W_INIT_TEXT, W_TITLE);
			}
			if (textMode == Open && Keyboard::oskdialog_mode == Keyboard::MODE_EXIT) {
				textMode = JustClosed;
				usleep(1000);
			}
			usleep(100);
		}
		sys_ppu_thread_exit(0);
	}
}