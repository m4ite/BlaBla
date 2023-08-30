import { Cargo } from "../CargoService/Cargo";
import { User } from "../UserService/User";

export interface Member
{
   cargo: Cargo,
   person: User
}