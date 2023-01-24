#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMSgOnlineModeCommand : public IMessageInfo
	{
	public:
		CMSgOnlineModeCommand(void);
		virtual ~CMSgOnlineModeCommand(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		int nID;
	};
}