// hello.cpp: Chello 的实现

#include "pch.h"
#include "hello.h"


// Chello



STDMETHODIMP Chello::hahaha(LONG* a)
{
	// TODO: 在此处添加实现代码
	printf("%d",&a);
	return S_OK;
}
