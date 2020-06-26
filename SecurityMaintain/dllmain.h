// dllmain.h: 模块类的声明。

class CSecurityMaintainModule : public ATL::CAtlDllModuleT< CSecurityMaintainModule >
{
public :
	DECLARE_LIBID(LIBID_SecurityMaintainLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_SECURITYMAINTAIN, "{87213bf3-b4a8-482c-9681-fed4ede9e05c}")
};

extern class CSecurityMaintainModule _AtlModule;
