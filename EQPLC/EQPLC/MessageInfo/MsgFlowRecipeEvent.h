#pragma once

#include "../MessageInfo.h"

#pragma warning(push)
#pragma warning(disable : 4786)
#include <vector>
#include <algorithm>
#include "afxwin.h"
#pragma warning(pop) 
using namespace std;

namespace Message
{
class CMsgFlowRecipeEvent : public IMessageInfo
{
public:
	struct FLOW_RECIPE_BODY
	{
		CString strFlowID;
		short nFlowNo;
		short nRevision;
		CString strTime;
		short nFlowBody[10];
	};
public:
	CMsgFlowRecipeEvent(void);
	virtual ~CMsgFlowRecipeEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }
	void Add(CString &strFlowID, short nFlowNo, short nRevision, CString &strTime, short* pFlowBody);
	void Add(const char* szFlowID, short nFlowNo, short nRevision, CString &strTime, short* pFlowBody);

public:
	short nEventID;
	//short nFlowNo;
	vector<FLOW_RECIPE_BODY *> m_vtFlowBody;
};
}