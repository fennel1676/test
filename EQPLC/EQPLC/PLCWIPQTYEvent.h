#pragma once


#include "IPLC.h"

namespace PLC
{
	class CPLCWIPQTYEvent : public IPLC
	{
	public:
		CPLCWIPQTYEvent(void);
		virtual ~CPLCWIPQTYEvent(void);

	public:
		virtual void SetData(const char *szTagName, char *pData);

	private:
		WIPQTY stWIPQTY;
	};
}
