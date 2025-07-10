cmake_minimum_required(VERSION 3.15)
project(AgxCpp LANGUAGES CXX)

file(GLOB SOURCES "*.cpp")

add_library(AgxCpp SHARED ${SOURCES})

set_target_properties(AgxCpp PROPERTIES
    WINDOWS_EXPORT_ALL_SYMBOLS ON
    OUTPUT_NAME "AgxCpp"
)