#include "StdAfx.h"
#include "ABConfig.h"
#include "XMLParser.h"
#include <afxstr.h>

vector<CABConfig::TAG_INFO *> CABConfig::g_vtTag;
CString CABConfig::g_strLocalIP;
int		CABConfig::g_nLocalRate = 20;
CString CABConfig::g_strLCIP;
int		CABConfig::g_nLCPort = 8001;
CString CABConfig::g_strPLC1IP;
CString CABConfig::g_strPLC2IP;

CString CABConfig::g_strEQ1Caption;
CString CABConfig::g_strEQ2Caption;

int CABConfig::g_nEQStartCount;
int CABConfig::g_nKeepAlive;
int CABConfig::g_nWaitCnt;

int CABConfig::g_nLogTime;
int CABConfig::g_nBinary;
int CABConfig::g_nXML;

CString CABConfig::g_strLog;
CString CABConfig::g_strBinaryLog;
CString CABConfig::g_strStateLog;
CString CABConfig::g_strConfig;
CString CABConfig::g_strSMD;
CString CABConfig::g_strXMLlog;
BOOL CABConfig::g_bTerminalSignal;
BOOL CABConfig::g_bOPCallSignal;
BOOL CABConfig::g_bTerminalSignal_PLC;
BOOL CABConfig::g_bOPCallSignal_PLC;

//ProcessCommandTest
CString CABConfig::g_strTestLog;


CABConfig::CABConfig(void)
{
}

CABConfig::~CABConfig(void)
{
}

void CABConfig::free()
{
	for_each(g_vtTag.begin(), g_vtTag.end(), DeleteAllObject());
	g_vtTag.erase(remove(g_vtTag.begin(), g_vtTag.end(), static_cast<TAG_INFO *>(0)), g_vtTag.end());	
}

void CABConfig::load(const char *szFile)
{
	CFile file;
	file.Open(szFile, CFile::modeRead);
	long nFileLength = file.SeekToEnd();
	char *szXML = new char[nFileLength + 1];
	memset(szXML, 0x00, nFileLength + 1);

	file.SeekToBegin();
	file.Read(szXML, nFileLength + 1);
	CString strBuf;
	CString strCommunication;
	strCommunication = CXMLParser::GetText(szXML, _T("COMMUNICATION"));
	CABConfig::g_strLocalIP = CXMLParser::GetText(strCommunication, _T("LOCAL_IP"));
	strBuf = CXMLParser::GetText(strCommunication, _T("LOCAL_RATE"));
	CABConfig::g_nLocalRate = atoi(strBuf);
	CABConfig::g_strLCIP = CXMLParser::GetText(strCommunication, _T("LC_IP"));
	strBuf = CXMLParser::GetText(strCommunication, _T("LC_PORT"));
	CABConfig::g_nLCPort = atoi(strBuf);

	CABConfig::g_strEQ1Caption = CXMLParser::GetText(strCommunication, _T("EQ1_CAPTION"));
	CABConfig::g_strEQ2Caption = CXMLParser::GetText(strCommunication, _T("EQ2_CAPTION"));
	
	CABConfig::g_strPLC1IP = CXMLParser::GetText(strCommunication, _T("EQ1_IP"));
	
	strBuf = CXMLParser::GetText(strCommunication, _T("EQ1_CNT"));
	CABConfig::g_nEQStartCount = atoi(strBuf);
	
	

	strBuf = CXMLParser::GetText(strCommunication, _T("EQ1_ALIVE"));
	CABConfig::g_nKeepAlive = atoi(strBuf);
	
	strBuf = CXMLParser::GetText(strCommunication, _T("EQ1_WAIT"));
	CABConfig::g_nWaitCnt = atoi(strBuf);

	// Log삭제 기간 설정
	strBuf = CXMLParser::GetText(strCommunication, _T("LogTime"));
	CABConfig::g_nLogTime = atoi(strBuf);


	// 1 Log On, else OFF	
	strBuf = CXMLParser::GetText(strCommunication, _T("BINARY"));
	CABConfig::g_nBinary = atoi(strBuf);

	// 1 Log On, else OFF
	strBuf = CXMLParser::GetText(strCommunication, _T("_XML_"));
	CABConfig::g_nXML = atoi(strBuf);

	CABConfig::g_strLog = CXMLParser::GetText(strCommunication, _T("LOG"));

	CABConfig::g_strBinaryLog = CXMLParser::GetText(strCommunication, _T("BIN_LOG"));

	CABConfig::g_strStateLog = CXMLParser::GetText(strCommunication, _T("STATE_LOG"));

	CABConfig::g_strConfig = CXMLParser::GetText(strCommunication, _T("CONFIG"));

    CABConfig::g_strSMD = CXMLParser::GetText(strCommunication, _T("SMD"));

	CABConfig::g_strXMLlog = CXMLParser::GetText(strCommunication, _T("XML_LOG"));

	CABConfig::g_strTestLog = CXMLParser::GetText(strCommunication, _T("TEST_LOG"));

	std::vector<CString> vtPLC = CXMLParser::GetTexts(szXML, _T("PLC"));
	CABConfig::TAG_INFO* pTagInfo = NULL;
	for(int i = 0; i < vtPLC.size(); i++)
	{
		std::vector<CString> vtTag = CXMLParser::GetTexts(vtPLC[i], _T("TAG"));
		for(int j = 0; j < vtTag.size(); j++)
		{
			pTagInfo = new TAG_INFO;
			pTagInfo->nPLCNo = i;
			pTagInfo->strName = CXMLParser::GetText(vtTag[j], _T("NAME"));
			pTagInfo->strType = CXMLParser::GetText(vtTag[j], _T("TYPE"));
			strBuf = CXMLParser::GetText(vtTag[j], _T("SAVE"));
			pTagInfo->nSave = atoi(strBuf);
			strBuf = CXMLParser::GetText(vtTag[j], _T("OUT"));
			pTagInfo->nOut = atoi(strBuf);
			strBuf = CXMLParser::GetText(vtTag[j], _T("CONNECT"));
			pTagInfo->nConnect = atoi(strBuf);
			CABConfig::g_vtTag.push_back(pTagInfo);
		}
	}
	file.Close();

	delete szXML;
}
