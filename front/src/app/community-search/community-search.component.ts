import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Community } from '../Services/CommunityService/Community';
import { SearchService } from '../Services/SearchService/search.service';

@Component({
  selector: 'app-community-search',
  templateUrl: './community-search.component.html',
  styleUrls: ['./community-search.component.css']
})
export class CommunitySearchComponent {

  constructor(private router: Router, private service: SearchService) { }

  serchValue = "";
  sla = ""
  dataCommunity: Community[] = [];
  vazio = false
  count = 0

  search()
  {
    this.count = 0
    this.vazio = false
    this.dataCommunity = []
    this.service.search(this.serchValue)
    .subscribe(res => {
      res.forEach(value => {
        this.dataCommunity.push(value)
      })
      this.sla = this.serchValue
      this.count = this.dataCommunity.length
      if(this.dataCommunity.length == 0)
      {
         this.vazio = true
      }
       
    })

    
    this.router.navigate(['/searchCommunity/' + this.serchValue])
  }
}
