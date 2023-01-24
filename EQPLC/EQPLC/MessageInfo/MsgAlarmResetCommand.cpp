#include "StdAfx.h"
#include "MsgAlarmResetCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgAlarmResetCommand::CMsgAlarmResetCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 12;

	nCommandID = 0;
	nCount = 0;
	nByWho = 0;
	memset(stClearAlarm, 0x00, sizeof(CLEAR_ALARM) * 20);
}

CMsgAlarmResetCommand::~CMsgAlarmResetCommand(void)
{

}

bool CMsgAlarmResetCommand::ParseMsg(const CString& strXML) 
{
	CString strBuf;
	strBuf = CXMLParser::GetText(strXML, _T("ID"));
	nCommandID = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("COUNT"));
	nCount = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("BYWHO"));
	nByWho = atoi(strBuf);

	std::vector<CString> vtNo = CXMLParser::GetTexts(strXML, _T("NO"));

	for(int i = 0; i < vtNo.size(); i++)
	{
		stClearAlarm[i].nUnitNo = atoi(vtNo[i]) / 32 + 1;
		stClearAlarm[i].nAlarmNo = atoi(vtNo[i]) % 32;
	}

	return true;
}