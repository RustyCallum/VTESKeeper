import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayersPagePopupComponent } from './players-page-popup.component';

describe('PlayersPagePopupComponent', () => {
  let component: PlayersPagePopupComponent;
  let fixture: ComponentFixture<PlayersPagePopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlayersPagePopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayersPagePopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
