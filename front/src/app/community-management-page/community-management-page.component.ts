import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommunityService } from '../Services/CommunityService/community.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Community } from '../Services/CommunityService/Community';
import { Cargo } from '../Services/CargoService/Cargo';
import { CargoService } from '../Services/CargoService/cargo.service';

@Component({
  selector: 'app-community-management-page',
  templateUrl: './community-management-page.component.html',
  styleUrls: ['./community-management-page.component.css']
})
export class CommunityManagementPageComponent implements OnInit, OnDestroy {


  constructor(private cargoService: CargoService, private service: CommunityService, private route: ActivatedRoute) { }

  subscription: any;
  community : Community = 
  {
    title: '',
    descrip: '',
    foto: ''
  }

  cargo : Cargo = 
  {
    nome: '',
    editMembers: false,
    addPost: false,
    createCargo: false,
    editCommunity: false,
    deleteCommunity: false,
  }
  qtd = 0 


  ngOnInit(): void {
    const jwt = sessionStorage.getItem("jwt") ?? ""
    this.subscription = this.route.params.subscribe(params => {
      this.community.title = params['title'];
      });

    this.service.getCommunity(this.community.title, jwt)
    .subscribe(res =>
      {
        this.community.foto = res.foto
        this.community.descrip = res.descrip
      })

   
    this.cargoService.GetCargoByUser(this.community.title, jwt)
    .subscribe(res =>
      {
        this.cargo.nome = res.nome,
        this.cargo.addPost = res.addPost,
        this.cargo.createCargo = res.createCargo,
        this.cargo.deleteCommunity = res.deleteCommunity,
        this.cargo.editCommunity = res.editCommunity,
        this.cargo.editMembers = res.editMembers
        console.log(this.cargo)
      })

      console.log(this.community)
      console.log(this.cargo)
      console.log(jwt)
     
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    }


}
