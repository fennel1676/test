#include "StdAfx.h"
#include "MsgFlowGroupControlCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgFlowGroupControlCommand::CMsgFlowGroupControlCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 4;

	nCommandID = 0;
	memset(nBody, 0x00, sizeof(short) * 10);
}

CMsgFlowGroupControlCommand::~CMsgFlowGroupControlCommand(void)
{
}

bool CMsgFlowGroupControlCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("COMMAND"));
	nCommandID = atoi(strBuf);

	CString strBody = CXMLParser::GetText(strInfo, _T("BODY"));
	for(int i = 0; i < 10; i++)
	{
		AfxExtractSubString(strBuf, strBody, i, ' ');
		nBody[i] = atoi(strBuf);
	}

	return true; 
}