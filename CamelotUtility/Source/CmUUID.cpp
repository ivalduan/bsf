#include "CmUUID.h"
#include <boost/uuid/uuid.hpp>
#include <boost/uuid/uuid_generators.hpp>
#include <boost/uuid/uuid_io.hpp>

using namespace boost::uuids;

namespace CamelotFramework
{
	String UUIDGenerator::generateRandom()
	{
		static random_generator gen;

		uuid newUUID = gen();

		return to_string(newUUID).c_str();
	}
};