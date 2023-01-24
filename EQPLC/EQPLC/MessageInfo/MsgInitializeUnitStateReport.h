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
class CMsgInitializeUnitStateReport : public IMessageInfo
{
public:
	struct UNIT_STATE
	{
		int nUnitID;
		int nEQState;
		int nProcessState;
	};

public:
	CMsgInitializeUnitStateReport(void);
	virtual ~CMsgInitializeUnitStateReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }
	void Add(int nUnitID, int nEQState, int nProcessState);

private:
	int m_nUnitCount;
	UNIT_STATE m_stUnitState[81];
};
}