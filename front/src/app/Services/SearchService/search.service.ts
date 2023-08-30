import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Community } from '../CommunityService/Community';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  search(value: string)
  {
    return this.http.get<Community[]>('http://localhost:5020/search/' + value)
  }

}
