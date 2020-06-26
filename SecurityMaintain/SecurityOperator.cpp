// SecurityOperator.cpp: CSecurityOperator 的实现

#include "stdafx.h"
#include "SecurityOperator.h"
#include "SHA512.h"

#pragma comment(lib, "comsuppw.lib")


// CSecurityOperator


STDMETHODIMP CSecurityOperator::HashNameAndPassword(BSTR name, BSTR password, BSTR * hashValue)
{
	std::string userName = _com_util::ConvertBSTRToString(name);
	std::string userPassword = _com_util::ConvertBSTRToString(password);
	std::string hashOrigin = userPassword + userName;

	unsigned char sha512Code[64];
	SHA512_CB sha512;
	SHA512Init(&sha512);
	SHA512Update(&sha512, (unsigned char*)hashOrigin.c_str(), hashOrigin.length());
	SHA512Final(&sha512, sha512Code);

	char res[1280];
	int offset = 0;
	for (int i = 0; i < 64; i++)
	{
		offset += sprintf(res + offset, "%02x", sha512Code[i]);
	}
	*hashValue = _bstr_t(res);

	return S_OK;
}

STDMETHODIMP CSecurityOperator::CheckHash(BSTR hash1, BSTR hash2, VARIANT_BOOL* compare)
{
	std::string hashStr1 = _com_util::ConvertBSTRToString(hash1);
	std::string hashStr2 = _com_util::ConvertBSTRToString(hash2);
	*compare = (hashStr1 == hashStr2);

	return S_OK;
}
