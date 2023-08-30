import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommunityService } from '../Services/CommunityService/community.service';
import { Community } from '../Services/CommunityService/Community';
import { MemberService } from '../Services/MemberService/member.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-new-community-page',
  templateUrl: './new-community-page.component.html',
  styleUrls: ['./new-community-page.component.css']
})
export class NewCommunityPageComponent {

  title = ""
  photo : string = ""
  description = ""

  foto = ""
  validation = false
  erro = ""
  
  constructor(private communityService: CommunityService, private router: Router, private memberService : MemberService) {}


  createCommunity() {

    const jwt = sessionStorage.getItem("jwt")
    console.log("jwt", jwt)

    this.foto = this.photo

    if (this.photo == "") {
      this.foto = './assets/communityDefautl.png'
    }
    else
    {
      var list = this.photo.split("\\")
      var item = list[list.length-1]
      this.foto = "./assets/community/" + item
    }

    let community : Community =  
    {
      title: this.title,
      descrip: this.description,
      foto: this.foto
    };

      this.communityService.Add(community, jwt!)
      .subscribe({
        next: (res: any) => {
        this.router.navigate(["/feed"]);
        },
        error: (error: HttpErrorResponse) => {
          if(error.error == "Já existe uma comunidade com esse nome!")
          {
            this.erro = error.error
            this.validation = true
          }
          
        }
      })
  }
}
