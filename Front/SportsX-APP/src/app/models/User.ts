import { Phone } from './Phone';

export interface User {
  id: number;

  fullName: string;

  companyName?: string;

  document?: string;

  email: string;

  cep?: string;

  classification: number;

  phones: Phone[];
}
