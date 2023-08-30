import { Component } from '@angular/core';
import { Community } from '../Services/CommunityService/Community';
import { Member } from '../Services/MemberService/Member';
import { MemberService } from '../Services/MemberService/member.service';
import { ActivatedRoute } from '@angular/router';
import { User } from '../Services/UserService/User';
import { CargoService } from '../Services/CargoService/cargo.service';

@Component({
  selector: 'app-members-page',
  templateUrl: './members-page.component.html',
  styleUrls: ['./members-page.component.css']
})
export class MembersPageComponent {
  dataMember: User[] = [];
  subscription: any;
  title = ""

  constructor(private service: MemberService, private route: ActivatedRoute, private cargoservice : CargoService) { }

  ngOnInit(): void {
    const jwt = sessionStorage.getItem("jwt") ?? ""

    this.subscription = this.route.params.subscribe(params => {
      this.title = params['title'];
    });

    ///////////////////////////////////////////////////////////////////////////
    
    this.service.getAllMembers(this.title)
      .subscribe(res => {
        res.forEach(member => {
          console.log(member)
          this.dataMember.push(member)
        });
      })
  }


}
