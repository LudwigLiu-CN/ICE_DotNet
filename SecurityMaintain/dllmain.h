// dllmain.h: 模块类的声明。

class CSecurityMaintainModule : public ATL::CAtlDllModuleT< CSecurityMaintainModule >
{
public :
	DECLARE_LIBID(LIBID_SecurityMaintainLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_SECURITYMAINTAIN, "{0a3fa73a-d0c0-48db-8c11-e4e6b1809cb2}")
};

extern class CSecurityMaintainModule _AtlModule;
