import { Classification } from "./Classification.enum";
import { Phone } from "./Phone";

export interface User {
  id: string;

  fullName: string;

  companyName: string;

  document: string;

  email: string;

  cEP: string;

  classification: Classification;

  phones: Phone[];
}
