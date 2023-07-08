#pragma once

#include <sys/prx.h>
#include <cellstatus.h>
#include <wchar.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/syscall.h>
#include <sys/ppu_thread.h>
#include <string.h>
#include <sys/sys_time.h>
#include <sys/time_util.h>
#include <stdarg.h>
#include <assert.h>
#include <sys/process.h>
#include <sys/memory.h>
#include <sys/timer.h>
#include <sys/return_code.h>
#include <stddef.h>
#include <math.h>
#include <stdarg.h>
#include <cellstatus.h>
#include <typeinfo>
#include <vector>
#include <pthread.h>
#include <locale.h>
#include <cell/error.h>
#include <sys/paths.h> 
#include <sys/fs.h> 
#include <sys/fs_external.h> 
#include <cell/cell_fs.h>
#include <cell/fs/cell_fs_file_api.h>
#include <time.h>
#include <sys/return_code.h>
#include <sysutil/sysutil_oskdialog.h>
#include <sysutil/sysutil_msgdialog.h>

namespace Dialog
{
	bool Finished = false;
	bool YESNO = false;

	enum {
		MODE_IDLE = 0,
		MODE_ERRORCODE_DIALOG_TEST,
		MODE_STRING_OK,
		MODE_STRING_YESNO,
		MODE_STRING_DIALOG_3,
		MODE_STRING_DIALOG_4,
		MODE_STRING_DIALOG_5,
		MODE_CHECK_PROGRESSBAR_1,
		MODE_RUNNING,
		MODE_CHECK_TIMEOUT,
		MODE_TIMEOUT_NEXT,
		MODE_EXIT
	};

	static int msgdialog_mode = MODE_IDLE;

	static void cb_dialogText1(int button_type, void *userdata)
	{
		switch (button_type) {

		case CELL_MSGDIALOG_BUTTON_OK:
			msgdialog_mode = MODE_EXIT;
			break;
		case CELL_MSGDIALOG_BUTTON_ESCAPE:
			msgdialog_mode = MODE_EXIT;
			break;

		default:
			msgdialog_mode = MODE_EXIT;
			break;
		}
	}
	void ProgressBar(const char* msg, const char* Secondmessage, int DisplayInSeconds)
	{
		unsigned int type = CELL_MSGDIALOG_TYPE_SE_TYPE_NORMAL
			| CELL_MSGDIALOG_TYPE_BUTTON_TYPE_NONE
			| CELL_MSGDIALOG_TYPE_DISABLE_CANCEL_ON
			| CELL_MSGDIALOG_TYPE_DEFAULT_CURSOR_NONE
			| CELL_MSGDIALOG_TYPE_PROGRESSBAR_SINGLE;
		cellMsgDialogOpen2(type, msg, NULL, NULL, NULL);
		cellMsgDialogProgressBarSetMsg(CELL_MSGDIALOG_PROGRESSBAR_INDEX_DOUBLE_UPPER, Secondmessage);
		cellMsgDialogProgressBarInc(CELL_MSGDIALOG_PROGRESSBAR_INDEX_SINGLE, 100);
		cellMsgDialogClose(DisplayInSeconds * 1000);
	}
	static void cb_dialogText2(int button_type, void *userdata)
	{
		switch (button_type) {

		case CELL_MSGDIALOG_BUTTON_YES:
			YESNO = true;
			msgdialog_mode = MODE_EXIT;
			Finished = true;
			break;

		case CELL_MSGDIALOG_BUTTON_NO:
			msgdialog_mode = MODE_EXIT;
			Finished = true;
			break;

		case CELL_MSGDIALOG_BUTTON_ESCAPE:
			msgdialog_mode = MODE_EXIT;
			Finished = true;
			break;

		default:
			break;
		}
	}


	void ShowYESNO(char* msg)
	{
		unsigned int type = CELL_MSGDIALOG_TYPE_SE_TYPE_NORMAL
			| CELL_MSGDIALOG_TYPE_BG_INVISIBLE
			| CELL_MSGDIALOG_TYPE_BUTTON_TYPE_YESNO
			| CELL_MSGDIALOG_TYPE_DISABLE_CANCEL_ON
			| CELL_MSGDIALOG_TYPE_DEFAULT_CURSOR_YES;


		switch (msgdialog_mode)
		{
		case MODE_IDLE:
			break;

		case MODE_STRING_YESNO:
			cellMsgDialogOpen2(type, msg, cb_dialogText2, NULL, NULL);
			msgdialog_mode = MODE_RUNNING;
			break;

		case MODE_EXIT:
			cellMsgDialogClose((float)1);
			break;

		default:
			break;

		}


	}
	void Show(char* msg)
	{

		unsigned int type = CELL_MSGDIALOG_TYPE_SE_TYPE_ERROR
			| CELL_MSGDIALOG_TYPE_BG_INVISIBLE
			| CELL_MSGDIALOG_TYPE_BUTTON_TYPE_OK
			| CELL_MSGDIALOG_TYPE_DISABLE_CANCEL_ON
			| CELL_MSGDIALOG_TYPE_DEFAULT_CURSOR_OK;


		switch (msgdialog_mode)
		{
		case MODE_IDLE:
			break;

		case MODE_STRING_OK:
			cellMsgDialogOpen2(type, msg, cb_dialogText1, NULL, NULL);
			msgdialog_mode = MODE_EXIT;
			break;

		case MODE_EXIT:
			cellMsgDialogClose((float)5);
			break;

		default:
			break;

		}

		while (Dialog::msgdialog_mode != Dialog::MODE_EXIT){}  //wait for the dialog to end :P
	}

	void End()
	{
		Finished = false;
		YESNO = false;
	}


}

namespace Keyboard
{
	enum{
		MODE_IDLE = 0,
		MODE_OPEN,
		MODE_RUNNING,
		MODE_CLOSE,
		MODE_ENTERED,
		MODE_CANCELED,
		SET_ABORT_TIMER,
		CHANGE_PANEL_MODE,
		CHANGE_SCALE,
		SET_CALLBACK,
		MODE_EXIT,
		START_DIALOG_TYPE,
		START_SEPARATE_TYPE_1,
		START_SEPARATE_TYPE_2,
	};
	static int oskdialog_mode = MODE_IDLE;

	int getkbLen(char* str)
	{
		int nullCount = 0;
		int i = 0; //num of chars..
		for (i = 0; i < 64; i++)
		{
			if (nullCount == 2){ break; }
			if (*(str + i) == 0x00) { nullCount++; }
			else { nullCount = 0; }
		}
		return i;
	}
	void makekbStr(char* str, char* dest, int len)
	{
		int nulls = 0;
		for (int i = 0; i < len; i++)
		{
			if (*(str + i) == 0x00) { nulls++; }
			else { *(dest + i - nulls) = *(str + i); }
		}
		*(dest + len + 1 - nulls) = 0x00;  //make sure its nulled...
	}

	static void sysutil_callback(uint64_t status, uint64_t param, void *userdata)
	{
		(void)param;
		(void)userdata;
		int ret = 0;

		switch (status){
		case CELL_SYSUTIL_OSKDIALOG_LOADED:
			break;
		case CELL_SYSUTIL_OSKDIALOG_FINISHED:
			oskdialog_mode = MODE_CLOSE;
			break;
		case CELL_SYSUTIL_OSKDIALOG_UNLOADED:
			break;
		case CELL_SYSUTIL_REQUEST_EXITGAME:
			oskdialog_mode = MODE_EXIT;
			break;
		case CELL_SYSUTIL_DRAWING_BEGIN:
			break;
		case CELL_SYSUTIL_DRAWING_END:
			break;
		case CELL_SYSUTIL_OSKDIALOG_INPUT_ENTERED:
			oskdialog_mode = MODE_ENTERED;
			break;
		case CELL_SYSUTIL_OSKDIALOG_INPUT_CANCELED:
			oskdialog_mode = MODE_CANCELED;
			break;
		case CELL_SYSUTIL_OSKDIALOG_INPUT_DEVICE_CHANGED:
			break;
		case CELL_SYSUTIL_OSKDIALOG_DISPLAY_CHANGED:
			break;
		case CELL_SYSUTIL_SYSTEM_MENU_CLOSE:

			break;
		case CELL_SYSUTIL_SYSTEM_MENU_OPEN:
			break;
		default:
			break;
		}
	}
	int keyboard(char* dest, wchar_t* INIT_TEXT, wchar_t* MESSAGE)
	{


#pragma region Declarations

		int ret;
		CellOskDialogInputFieldInfo inputFieldInfo;
		inputFieldInfo.message = (uint16_t*)MESSAGE;
		inputFieldInfo.init_text = (uint16_t*)INIT_TEXT;
		inputFieldInfo.limit_length = CELL_OSKDIALOG_STRING_SIZE;


		CellOskDialogCallbackReturnParam OutputInfo;
		OutputInfo.result = CELL_OSKDIALOG_INPUT_FIELD_RESULT_OK;
		OutputInfo.numCharsResultString = 32;

		uint16_t Result_Text_Buffer[CELL_OSKDIALOG_STRING_SIZE + 1];
		OutputInfo.pResultString = Result_Text_Buffer;

		ret = cellOskDialogSetKeyLayoutOption(CELL_OSKDIALOG_10KEY_PANEL | CELL_OSKDIALOG_FULLKEY_PANEL);


		CellOskDialogPoint pos;
		pos.x = 0.0;  pos.y = 0.0;
		int32_t LayoutMode = CELL_OSKDIALOG_LAYOUTMODE_X_ALIGN_CENTER | CELL_OSKDIALOG_LAYOUTMODE_Y_ALIGN_TOP;
		ret = cellOskDialogSetLayoutMode(LayoutMode);


		CellOskDialogParam dialogParam;
		dialogParam.allowOskPanelFlg = CELL_OSKDIALOG_PANELMODE_KOREAN |
			CELL_OSKDIALOG_PANELMODE_ALPHABET |
			CELL_OSKDIALOG_PANELMODE_NUMERAL_FULL_WIDTH |
			CELL_OSKDIALOG_PANELMODE_NUMERAL |
			CELL_OSKDIALOG_PANELMODE_JAPANESE |
			CELL_OSKDIALOG_PANELMODE_JAPANESE_KATAKANA |
			CELL_OSKDIALOG_PANELMODE_ENGLISH;
		/*E Panel to display first */
		dialogParam.firstViewPanel = CELL_OSKDIALOG_PANELMODE_ALPHABET;
		/* E Initial display position of the on-screen keyboard dialog */
		dialogParam.controlPoint = pos;
		/*E Prohibited operation flag(s) (ex. CELL_OSKDIALOG_NO_SPACE) */
		dialogParam.prohibitFlgs = 0;


#pragma endregion

		sys_timer_usleep(16 * 1000);
		ret = cellSysutilCheckCallback();


		if (oskdialog_mode == MODE_OPEN)
		{
			if (cellSysutilRegisterCallback(0, sysutil_callback, NULL) != 0) { }
			ret = cellOskDialogLoadAsync(SYS_MEMORY_CONTAINER_ID_INVALID, &dialogParam, &inputFieldInfo);
			oskdialog_mode = MODE_RUNNING;
		}

		if (oskdialog_mode == MODE_ENTERED)
		{
			ret = cellOskDialogGetInputText(&OutputInfo);
			oskdialog_mode = MODE_RUNNING;
		}
		if (oskdialog_mode == MODE_CLOSE)
		{
			ret = cellOskDialogUnloadAsync(&OutputInfo);

			int strLen = getkbLen((char*)(*(&OutputInfo.pResultString)));
			makekbStr((char*)(*(&OutputInfo.pResultString)), dest, strLen);
			inputFieldInfo.init_text = (uint16_t*)INIT_TEXT;
			if (cellSysutilUnregisterCallback(0) != 0) {  }
			oskdialog_mode = MODE_EXIT;
		}

		return 0;
	}


}