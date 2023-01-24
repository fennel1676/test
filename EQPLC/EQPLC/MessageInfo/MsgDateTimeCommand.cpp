#include "StdAfx.h"
#include "MsgDateTimeCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgDateTimeCommand::CMsgDateTimeCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 1;
}


CMsgDateTimeCommand::~CMsgDateTimeCommand(void)
{}


bool CMsgDateTimeCommand::ParseMsg(const CString& strXML) 
{ 
	strDateTime = CXMLParser::GetText(strXML, _T("DATETIME"));
	return strDateTime.IsEmpty() == FALSE; 
}