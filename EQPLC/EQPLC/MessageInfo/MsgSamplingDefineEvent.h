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
class CMsgSamplingDefineEvent : public IMessageInfo
{
public:
	struct SAMPLING_DEFINE
	{
		short nUnitNo;
		short nRuleType;
		char szProductID[24];
		char szProcessID[24];
		char szStepID[16];
		short nStandardSpec;
		short nSamplingCount;
		short nCurrentSamplingCount;
		short nTotalSamplingCount;
		char szJudgement[4];
		long nTarget;
		short nSamplingUseFlag;
		short nTotalGlassCount;
	};

public:
	CMsgSamplingDefineEvent(void);
	virtual ~CMsgSamplingDefineEvent(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	vector<SAMPLING_DEFINE *> vtSamplingDefine;
};
}