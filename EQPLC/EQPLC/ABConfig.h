#pragma once

#pragma warning(push)
#pragma warning(disable : 4786)
#include <vector>
#include <algorithm>
#include "afxwin.h"
#pragma warning(pop) 
using namespace std;

class CABConfig
{
public:
	struct TAG_INFO
	{
		int nPLCNo;
		CString strName;
		CString strType;
		int nSave;
		int nOut;
		int nConnect;
	};
public:
	CABConfig(void);
	~CABConfig(void);

	static void load(const char *szFile);
	static void free();

public:
	static vector<TAG_INFO *> g_vtTag;
	static CString g_strLocalIP;
	static int g_nLocalRate;
	static CString g_strLCIP;
	static int g_nLCPort;
	static int g_nLogTime;
	static int g_nBinary;
	static int g_nXML;
	static CString g_strEQ1Caption;
	static CString g_strEQ2Caption;
	static CString g_strPLC1IP;
	static CString g_strPLC2IP;
	static int g_nKeepAlive;
	static int g_nWaitCnt;
	static int g_nEQStartCount;
	static CString g_strLog;
	static CString g_strBinaryLog;
	static CString g_strStateLog;
	static CString g_strXMLlog;	
	static CString g_strConfig;
	static CString g_strSMD;
	static BOOL g_bTerminalSignal;
	static BOOL g_bOPCallSignal;
	static BOOL g_bTerminalSignal_PLC;
	static BOOL g_bOPCallSignal_PLC;

	//ProcessCommandTest
	static CString g_strTestLog;
	//
};
