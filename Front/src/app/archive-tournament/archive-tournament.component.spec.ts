import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArchiveTournamentComponent } from './archive-tournament.component';

describe('ArchiveTournamentComponent', () => {
  let component: ArchiveTournamentComponent;
  let fixture: ComponentFixture<ArchiveTournamentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ArchiveTournamentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArchiveTournamentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
