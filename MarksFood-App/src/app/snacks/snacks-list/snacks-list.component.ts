import { Component, OnInit } from '@angular/core';
import { Snack } from 'src/app/core/models/snack';
import { SnacksService } from '../snacks.service';

@Component({
  selector: 'app-snacks-list',
  templateUrl: './snacks-list.component.html',
  styleUrls: ['./snacks-list.component.scss']
})
export class SnacksListComponent implements OnInit {
	snacks: Snack[];

	constructor(private snacksService: SnacksService) { }

  	ngOnInit() {
    	this.loadSnacks();
  	}

  	loadSnacks(){
    	this.snacksService.listSnacks().subscribe(snack => {      	
      		this.snacks = snack;
    	});
  	}
}
