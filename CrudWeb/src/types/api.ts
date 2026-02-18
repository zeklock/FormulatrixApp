import type { UserType } from "./auth";

export interface ApiResponseType<T> {
  success: boolean;
  message: string;
  data: T;
  errors?: string[];
}

export interface LoginResponseData {
  token: string;
  user: UserType;
}
