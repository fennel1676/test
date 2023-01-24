#include "StdAfx.h"
#include "MsgLimitWIPQTYCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgLimitWIPQTYCommand::CMsgLimitWIPQTYCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 17;

	nLimitWIPQTY1 = 0;
	nLimitWIPQTY2 = 0;
}

CMsgLimitWIPQTYCommand::~CMsgLimitWIPQTYCommand(void)
{
}

bool CMsgLimitWIPQTYCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("LIMITWIPQTY1"));
	nLimitWIPQTY1 = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("LIMITWIPQTY2"));
	nLimitWIPQTY2 = atoi(strBuf);

	return true; 
}