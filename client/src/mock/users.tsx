export interface MockUser {
  id: number;
  name: string;
  email: string;
  password: string;
  role: "Employee" | "Manager" | "Admin";
}

export const mockUsers: MockUser[] = [
  {
    id: 1,
    name: "John Doe",
    email: "employee@test.com",
    password: "123456",
    role: "Employee",
  },
  {
    id: 2,
    name: "Jane Smith",
    email: "manager@test.com",
    password: "123456",
    role: "Manager",
  },
  {
    id: 3,
    name: "Admin User",
    email: "admin@test.com",
    password: "123456",
    role: "Admin",
  },
];