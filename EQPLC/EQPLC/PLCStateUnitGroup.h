#pragma once

#include "IPLC.h"
#include "PLCState.h"
#include "PLCStateUnit.h"

namespace PLC
{
class CPLCStateUnitGroup : public IPLC
{
public:
	CPLCStateUnitGroup(void);
	virtual ~CPLCStateUnitGroup(void);

public:
	virtual void SetData(const char *szTagName, char *pData);
	virtual void SetTagName(CString strTagName);

private:
	CPLCStateUnit m_objPLCStateUnit[10];
};
}