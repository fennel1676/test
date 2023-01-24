#include "StdAfx.h"
#include "MsgPortStartCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgPortStartCommand::CMsgPortStartCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 17;

	nLine = 0;
	nBit = 0;
}

CMsgPortStartCommand::~CMsgPortStartCommand(void)
{
}

bool CMsgPortStartCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("LINE"));
	nLine = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("BIT"));
	nBit = atoi(strBuf);
	return true; 
}