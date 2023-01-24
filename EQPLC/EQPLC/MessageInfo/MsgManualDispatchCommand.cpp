#include "StdAfx.h"
#include "MsgManualDispatchCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgManualDispatchCommand::CMsgManualDispatchCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 5;

	nDispatchOption = 0;
	nRunLine = 0;
	nTargetUnit = 0;
}

CMsgManualDispatchCommand::~CMsgManualDispatchCommand(void)
{
}

bool CMsgManualDispatchCommand::ParseMsg(const CString& strXML)
{
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("DISPATCH"));
	nDispatchOption = atoi(strBuf);

	strDeviceID = CXMLParser::GetText(strInfo, _T("DEVICEID"));

	strBuf = CXMLParser::GetText(strInfo, _T("RUNLINE"));
	nRunLine = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("UNIT"));
	nTargetUnit = atoi(strBuf);

	return true;
}
