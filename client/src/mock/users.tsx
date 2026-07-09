import type {  MockUser } from "../types";
// export interface MockUser {
//   id: number;
//   name: string;
//   email: string;
//   password: string;
//   role: "Employee" | "Manager" | "Admin";
//   phone: string;

// }

export const mockUsers: MockUser[] = [
  {
    id: 1,
    name: "John Doe",
    email: "employee@test.com",
    password: "123456",
    role: "Employee",
    phone: "123-456-7890",
    address:"Bangalore",
    department: "Development",
    designation: "Software Engineer",
    DateOfJoining: "2023-05-01",
  },
  {
    id: 2,
    name: "Jane Smith",
    email: "manager@test.com",
    password: "123456",
    role: "Manager",
    phone: "987-654-3210",
    address:"Bangalore",
    department: "Management",
    designation: "Project Manager",
    DateOfJoining: "2022-01-15",
  },
  {
    id: 3,
    name: "Admin User",
    email: "admin@test.com",
    password: "123456",
    role: "Admin",
    phone: "123-456-7890",
    address:"Bangalore",
    department: "Administration",
    designation: "Administrator",
    DateOfJoining: "2021-03-10",
  },
];