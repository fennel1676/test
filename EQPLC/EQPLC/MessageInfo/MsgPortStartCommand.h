#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortStartCommand : public IMessageInfo
	{
	public:
		CMsgPortStartCommand(void);
		virtual ~CMsgPortStartCommand(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		short nLine;
		short nBit;
	};
}