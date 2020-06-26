#include "pch.h"

#include "HandleAddress.h"

namespace HandleAddress {
	public ref class AddressHelper {
	public:
		static vector<string> separateAddresses(string Add) {
			AddressHandler^ addressHandler = gcnew AddressHandler(Add);
			addressHandler->separate();
			return addressHandler->getSeparate();
		}

		static string concatnateAddresses(vector<string> AddList) {
			AddressHandler^ addressHandler = gcnew AddressHandler(AddList);
			addressHandler->concatenate();
			return addressHandler->getAll();
		}

		static int add(int a, int b) {
			return a + b;
		}

	};
}