#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCGlassData : public IPLC
{
public:
	CPLCGlassData(void);
	virtual ~CPLCGlassData(void);

public:
	virtual void SetData(const char *szTagName, char *pData);
	virtual void SetTagName(CString strTagName);
	virtual int GetUnitNo()	{return m_nUnitNo;}

private:
	int m_nUnitNo;

public:
	GLASS_DATA m_stGlassData;
};
}