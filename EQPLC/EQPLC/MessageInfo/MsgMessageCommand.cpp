#include "StdAfx.h"
#include "MsgMessageCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgMessageCommand::CMsgMessageCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 11;

	nNum = 0;
}

CMsgMessageCommand::~CMsgMessageCommand(void)
{
}

bool CMsgMessageCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	strBuf = CXMLParser::GetText(strXML, _T("NUM"));
	nNum = atoi(strBuf);

	strTerminal = CXMLParser::GetText(strXML, _T("TERMINAL"));	
	strOPCall = CXMLParser::GetText(strXML, _T("OPCALL"));

	return true; 
}