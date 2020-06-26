#include "pch.h"


/// <summary>
/// �μ���RFC2045
/// </summary>

#if !defined(uchar)
typedef unsigned char uchar;
#endif

//                       1         2         3         4         5         6
//             01234567890123456789012345678901234567890123456789012345678901234
uchar tbl[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
uchar tbl_rev[256];

/// <summary>
/// ����tbl������tbl_rev
/// </summary>
void ReverseTable()
{
	for (int i = 0; i <= 0x40; i++)
		tbl_rev[tbl[i]] = i;
}

/// <summary>
/// ����tbl��ͬʱ����tbl_rev��
/// </summary>
/// <param name="tbl_data">�µ�tblֵ</param>
void WINAPI SetBase64Table(uchar* tbl_data)
{
	for (int i = 0; i < 65; i++)
		tbl[i] = tbl_data[i];
	ReverseTable();
}

/// <summary>
/// Base64Encode:��src����base64����,�����dst
/// </summary>
/// <param name="src">����Դ(������Base64���ֽ�����)</param>
/// <param name="lSrc">����Դ����</param>
/// <param name="dst">�������(���Base64��Ľ��)</param>
/// <param name="nDst">��������С(ע������base64���򣬲�ӦС��int((lSrc+2)/3)*4)</param>
/// <returns>�������</returns>
int WINAPI Base64Encode(void* src, int lSrc, char* dst, int nDst)
{
	uchar* s = (uchar*)src;
	uchar* d = (uchar*)dst;
	uchar s0, s1, s2;	//�ֽ�src
	uchar d0, d1, d2, d3;	//�ֽ�dst
	int i = lSrc;
	int r = 0;	//���ɳ���
	while (i > 0)
	{
		int nStub = 0;

		//step1:��ȡһ��
		switch (i)
		{
		case 1:
			s0 = *s++;
			s1 = '\0';
			s2 = '\0';
			nStub = 2;
			i = 0;
			break;
		case 2:
			s0 = *s++;
			s1 = *s++;
			s2 = '\0';
			nStub = 1;
			i = 0;
			break;
		default:
			s0 = *s++;
			s1 = *s++;
			s2 = *s++;
			nStub = 0;
			i -= 3;
			break;
		}

		//step2:����

		// src:000000 001111 111122 222222
		// dst:000000 111111 222222 333333
		d0 = s0 >> 2;
		d1 = ((s0 & 0x03) << 4) | (s1 >> 4);
		d2 = ((s1 & 0x0f) << 2) | (s2 >> 6);
		d3 = s2 & 0x3f;

		//step3:����
		if (nDst - r >= 4)
		{
			*d++ = tbl[d0];
			*d++ = tbl[d1];
			*d++ = nStub > 1 ? tbl[0x40] : tbl[d2];
			*d++ = nStub > 0 ? tbl[0x40] : tbl[d3];
			r += 4;
		}
		else
			return -1;
	}
	return r;
}

//
//	Base64Decode:��src����base64����,�����dst
//
//	src:	����Դ(Base64�ַ���)
//	lSrc:	����Դ����
//	dst:	�������(�������ֽ�����)
//	lDst:	��������С��ע������base64���򣬲�ӦС��(lSrc/4)*3
//
int WINAPI Base64Decode(char* src, int lSrc, void* dst, int nDst)
{
	uchar* s = (uchar*)src;
	uchar* d = (uchar*)dst;
	uchar s0, s1, s2, s3;	//�ֽ�src
	uchar d0, d1, d2;			//�ֽ�dst

	//step1:��ȡһ��+����
	int i = lSrc;
	int r = 0;						//���ɳ���
	while (i > 0)
	{
		if (i >= 4)
		{
			s0 = tbl_rev[*s++];
			s1 = tbl_rev[*s++];
			s2 = tbl_rev[*s++];
			s3 = tbl_rev[*s++];
			i -= 4;
		}
		else
			return -1;

		//step2:����

		// src:00000011 11112222 22333333
		// dst:00000000 11111111 22222222
		d0 = (s0 << 2) | ((s1 & 0x30) >> 4);
		*d++ = d0;
		r++;
		if (s2 == 0x40)
		{
			*d++ = '\0';
			*d++ = '\0';
		}
		else
		{
			d1 = (s1 << 4) | ((s2 & 0xfc) >> 2);
			*d++ = d1;
			r++;
			if (s3 == 0x40)
			{
				d2 = 0;
				*d++ = '\0';
			}
			else
			{
				d2 = (s2 << 6) | s3;
				*d++ = d2;
				r++;
			}
		}
	}
	return r;
}

int WINAPI test_fun() {
	return 123;
}