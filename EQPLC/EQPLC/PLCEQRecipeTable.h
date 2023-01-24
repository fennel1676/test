#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCEQRecipeTable : public IPLC
{
public:
	CPLCEQRecipeTable(void);
	virtual ~CPLCEQRecipeTable(void);

public:
	virtual void SetData(const char *szTagName, char *pData);

private:
	short m_nFlowGroup[10];
	short m_nEventID;
	short m_nFlowRecipeNo;
};
}
