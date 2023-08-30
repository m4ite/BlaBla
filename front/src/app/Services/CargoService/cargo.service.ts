import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cargo } from './Cargo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {

  constructor(private http: HttpClient) { }

  Add(cargo: Cargo, comTitle: string)
  {
    return this.http.post('http://localhost:5020/cargo/create/' + comTitle, cargo)
  }

  GetCargo(comTitle: string)
  {
    return this.http.get<Cargo[]>('http://localhost:5020/cargo/' + comTitle)
  }

  GetCargoByUser(comTitle: string, jwt: string)
  {
    return this.http.get<Cargo>('http://localhost:5020/cargo/User/' + comTitle + "/" + jwt)
  }


  Update(cargo:Cargo, comTitle: string)
  {
    return this.http.post('http://localhost:5020/cargo/update/' + comTitle, cargo)
  }

}
