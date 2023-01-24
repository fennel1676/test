#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCEQRecipeBody : public IPLC
{
public:
	CPLCEQRecipeBody(void);
	virtual ~CPLCEQRecipeBody(void);

public:
	virtual void SetData(const char *szTagName, char *pData);
	virtual void SetTagName(CString strTagName);

private:
	int m_nFlowRecipeStartIndex;
	FLOW_RECIPE_BODY m_stFlowRecipeBody[10];
};
}