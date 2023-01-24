#include "StdAfx.h"
#include "MsgFlowRecipeEvent.h"

using namespace Message;

CMsgFlowRecipeEvent::CMsgFlowRecipeEvent(void)
{
	m_nMessageType = 2;
	m_nMessageCommand = 1;
}

CMsgFlowRecipeEvent::~CMsgFlowRecipeEvent(void)
{
	for_each(m_vtFlowBody.begin(), m_vtFlowBody.end(), DeleteAllObject());
	m_vtFlowBody.erase(remove(m_vtFlowBody.begin(), m_vtFlowBody.end(), static_cast<FLOW_RECIPE_BODY *>(0)), m_vtFlowBody.end());	
}

void CMsgFlowRecipeEvent::Add(CString &strFlowID, short nFlowNo, short nRevision, CString &strTime, short* pFlowBody)
{
	FLOW_RECIPE_BODY *pFlowRecipeBody = new FLOW_RECIPE_BODY;
	pFlowRecipeBody->strFlowID = strFlowID;
	pFlowRecipeBody->nFlowNo = nFlowNo;
	pFlowRecipeBody->nRevision = nRevision;
	pFlowRecipeBody->strTime = strTime;
	memcpy(pFlowRecipeBody->nFlowBody, pFlowBody, sizeof(short) * 10);
	m_vtFlowBody.push_back(pFlowRecipeBody);
}

void CMsgFlowRecipeEvent::Add(const char* szFlowID, short nFlowNo, short nRevision, CString &strTime, short* pFlowBody)
{
	FLOW_RECIPE_BODY *pFlowRecipeBody = new FLOW_RECIPE_BODY;
	pFlowRecipeBody->strFlowID.Format(_T("%s"), szFlowID);
	pFlowRecipeBody->nFlowNo = nFlowNo;
	pFlowRecipeBody->nRevision = nRevision;
	pFlowRecipeBody->strTime = strTime;
	memcpy(pFlowRecipeBody->nFlowBody, pFlowBody, sizeof(short) * 10);
	m_vtFlowBody.push_back(pFlowRecipeBody);
}

const CString CMsgFlowRecipeEvent::GetMsg()
{
	if(0 >= m_vtFlowBody.size())	return "";

	CString msg;
	CString unitMsg;
	FLOW_RECIPE_BODY *pFlowBody = NULL;
	msg.Format(_T("<INFO>")_T("\n")
					_T("<ID>%d</ID>")_T("\n")		
					, nEventID);
	//msg.Format(_T("<INFO>")
	//	_T("<ID>%d</ID>")		
	//	_T("<NO>%d</NO>"), nEventID, nFlowNo);

	for(size_t i = 0; i < m_vtFlowBody.size(); i++)
	{
		pFlowBody = (FLOW_RECIPE_BODY *)m_vtFlowBody[i];
		unitMsg.Format(
			_T("<FLOW>")_T("\n")
				_T("<NO>%d</NO>")_T("\n")		
				_T("<ID>%s</ID>")"\r\n"		
				_T("<REVISION>%d</REVISION>")_T("\n")		
				_T("<TIME>%s</TIME>")"\r\n"		
				_T("<BODY>%d %d %d %d %d %d %d %d %d %d</BODY>")_T("\n")
			_T("</FLOW>"),
			pFlowBody->nFlowNo, pFlowBody->strFlowID, pFlowBody->nRevision, pFlowBody->strTime,
			pFlowBody->nFlowBody[0], pFlowBody->nFlowBody[1], pFlowBody->nFlowBody[2], pFlowBody->nFlowBody[3],
			pFlowBody->nFlowBody[4], pFlowBody->nFlowBody[5], pFlowBody->nFlowBody[6], pFlowBody->nFlowBody[7],
			pFlowBody->nFlowBody[8], pFlowBody->nFlowBody[9]);

		msg += unitMsg;
	}
	msg += _T("</INFO>");

	return msg;
}