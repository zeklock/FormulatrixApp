export interface LoginType {
  email: string;
  password: string;
}

export interface RegisterType extends LoginType {
  firstName: string;
  lastName: string;
}

export interface UserType {
  id: number;
  email: string;
  firstName: string;
  lastName: string;
}
