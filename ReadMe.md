## Railroad

### Project Specification:
The local railroad company needs a text interface to add new routes between towns, update the distance of the existing routes, and query existing routes.
Write a program which parses the commands given in the input text and then executes those commands, producing the desired output. The query command should output '-' in case there is no such route. (Think of utilizing the Command Pattern when thinking of a solution.)
We want you to build a .NET Core console application with included unit tests.

#### Input:
The input text describes a directed graph where a node represents a town and an edge represents a route between two towns. The weighting of the edge represents the distance between the two towns. For a given route, the starting and ending town will not be the same town.
In the test input given below, C-D:1 means there is a route from town C to town D and the distance of this route is 1. QUERY(C-D) asks for the current route distance from town C to D. Later in the test input, C-D:8 means the distance of the route from town C to D is updated as 8.

#### Test Input:
A-B:5, B-C:4, QUERY(A-B), C-D:1, D-C:8, D-E:6, QUERY(C-D), A-D:5, C-D:8, QUERY(C-D), C-E:2, E-B:3, QUERY(A-C), A-E:7

#### Output:
Only the QUERY commands generate an output. In the example output, A-B:5 is generated fror the QUERY(A-B) command, A-C:- is generated for the QUERY(A-C) command, since there is no direct route from A to C when this command is executed, distance for this non-existing route is displayed as '-'.

#### Test Output:
A-B:5

C-D:1

C-D:8

A-C:-
