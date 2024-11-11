using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Export Speed agar muncul di editor
	[Export]public float Speed = 300.0f;

	//variable untuk node Animation
	private AnimatedSprite2D _animated;

	// _ready dipanggil saat pertama kali node masuk kedalam schene tree
	public override void _Ready()
	{
		//dapatkan refrence ke Node AnimatedSprite2D
		_animated = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		//mainkan animasi 
		_animated.Play("idle_depan");
	}

	// dipangil setiap frame dan merupakan func khusus untuk physic proses
	//seperti movement dan semua intraksi berhubungan dengan physic
	public override void _PhysicsProcess(double delta)
	{
		//buat variable kosong untuk menampung arah tombol
		Vector2 dirrection = new Vector2();
		
		//setiap frame velocity akan di reset
		Velocity = Vector2.Zero;
		
		//saat input map "atas" ditekan
		if (Input.IsActionPressed("atas"))
		{
			dirrection.Y = -1;
			_animated.Play("idle_belakang");
		}
		
		//saat input map "bawah" ditekan
		if (Input.IsActionPressed("bawah"))
		{
			dirrection.Y = 1;
			_animated.Play("idle_depan");
		}
		
		//saat input map "kanan" ditekan
		if (Input.IsActionPressed("kanan"))
		{
			dirrection.X = 1;
			_animated.Play("idle_kanan");
		}
		
		//saat input map "kiri" ditekan
		if (Input.IsActionPressed("kiri"))
		{
			dirrection.X = -1;
			_animated.Play("idle_kiri");
		}
		
		
		Velocity = dirrection * Speed;
		MoveAndSlide();
	}

	public void ObjectEnterArea(Node2D body)
	{
		GD.Print(body.Name);
	}
}
