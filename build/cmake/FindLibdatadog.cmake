include(FetchContent)

set(LIBDATADOG_VERSION "v5.0.0" CACHE STRING "libdatadog version")

if (CMAKE_SYSTEM_PROCESSOR STREQUAL aarch64 OR CMAKE_SYSTEM_PROCESSOR STREQUAL arm64)
    if (DEFINED ENV{IsAlpine} AND "$ENV{IsAlpine}" MATCHES "true")
        set(SHA256_LIBDATADOG "f5fb14372b8d6018f4759eb81447dfec0d3393e8e4e44fe890c42045563b5de4" CACHE STRING "libdatadog sha256")
        set(FILE_TO_DOWNLOAD libdatadog-aarch64-alpine-linux-musl.tar.gz)
    else()
        set(SHA256_LIBDATADOG "2b3d1c5c3965ab4a9436aff4e101814eddaa59b59cb984ce6ebda45613aadbc3" CACHE STRING "libdatadog sha256")
        set(FILE_TO_DOWNLOAD libdatadog-aarch64-unknown-linux-gnu.tar.gz)
    endif()
else()
    if (DEFINED ENV{IsAlpine} AND "$ENV{IsAlpine}" MATCHES "true")
        set(SHA256_LIBDATADOG "060482ff1c34940cf7fad1dc841693602e04e4fa54ac9e9f08cb688efcbab137" CACHE STRING "libdatadog sha256")
        set(FILE_TO_DOWNLOAD libdatadog-${CMAKE_SYSTEM_PROCESSOR}-alpine-linux-musl.tar.gz)
    else()
        set(SHA256_LIBDATADOG "11c09440271dd4374b8fca8f0faa66c43a5e057aae05902543beb1e6cb382e52" CACHE STRING "libdatadog sha256")
        set(FILE_TO_DOWNLOAD libdatadog-${CMAKE_SYSTEM_PROCESSOR}-unknown-linux-gnu.tar.gz)
    endif()
endif()

FetchContent_Declare(libdatadog-${LIBDATADOG_VERSION}
    URL https://github.com/DataDog/libdatadog/releases/download/${LIBDATADOG_VERSION}/${FILE_TO_DOWNLOAD}
    URL_HASH SHA256=${SHA256_LIBDATADOG}
    SOURCE_DIR ${CMAKE_CURRENT_BINARY_DIR}/libdatadog-${LIBDATADOG_VERSION}
)
if(NOT libdatadog-${LIBDATADOG_VERSION}_POPULATED)
    FetchContent_Populate(libdatadog-${LIBDATADOG_VERSION})
endif()

set(LIBDATADOG_BASE_DIR ${libdatadog-${LIBDATADOG_VERSION}_SOURCE_DIR})

add_library(libdatadog-lib STATIC IMPORTED)

set_target_properties(libdatadog-lib PROPERTIES
    INTERFACE_INCLUDE_DIRECTORIES ${LIBDATADOG_BASE_DIR}/include
    IMPORTED_LOCATION ${LIBDATADOG_BASE_DIR}/lib/libdatadog_profiling.a
)

add_dependencies(libdatadog-lib libdatadog-${LIBDATADOG_VERSION})
