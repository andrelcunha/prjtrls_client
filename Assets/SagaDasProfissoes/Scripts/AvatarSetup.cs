using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Trilhas.Controller;
using Trilhas.JsonFormat;
using System.Linq;

public class AvatarSetup : MonoBehaviour
{
	[SerializeField] Image _generoImage;
	[SerializeField] Image _cabeloImage;
	[SerializeField] Image _peleImage;

	[SerializeField] Sprite[] _generoSprite;

	[SerializeField] Sprite[] _cabeloFSprite;
	[SerializeField] Sprite[] _cabeloMSprite;

	[SerializeField] Sprite[] _peleFSprite;
	[SerializeField] Sprite[] _peleMSprite;

	[SerializeField] int _gender;
	[SerializeField] int _skinColor;
	[SerializeField] int _hairColor;

	[SerializeField] SendAvatar sendAvatar;

	UserAvatar _avatarData;
	UserController _userController;
    
	#region Properties

	public int Gender
	{
		get
		{
			return _gender;
		}

		set
		{
			_gender = value;
			_generoImage.sprite = _generoSprite[_gender];
		}
	}

	public int HairColor
	{
		get
		{
			return _hairColor;
		}

		set
		{
			_hairColor = value;
			if (Gender == (int)GENDER.female)
			{
				_cabeloImage.sprite = _cabeloFSprite[_hairColor];
			}
			else
			{
				_cabeloImage.sprite = _cabeloMSprite[_hairColor];

			}
		}
	}

	public int SkinColor
	{
		get
		{
			return _skinColor;
		}

		set
		{
			_skinColor = value;
			if (Gender == (int)GENDER.female)
				_peleImage.sprite = _peleFSprite[_skinColor];
			else
				_peleImage.sprite = _peleMSprite[_skinColor];
		}
	}
    
	#endregion

	public Dictionary<int, string> skinCode = new Dictionary<int, string>
	{
		{0,"bc29b571-11a2-11e8-89d2-74d4359f41f2"},
		{1,"bc29a14e-11a2-11e8-89d2-74d4359f41f2"},
		{2,"dad772c5-32c2-11e8-989f-74d4359f41f2"},
		{3,"6a59c354-9fe2-11e8-885a-9061ae14951f"},
		{4,"74f0a924-11aa-11e8-89d2-74d4359f41f2"},
	};

	public Dictionary<int, string> hairCode = new Dictionary<int, string>
	{
		{0,"27a95637-11aa-11e8-89d2-74d4359f41f2"},
		{1,"fdec0ad4-119e-11e8-89d2-74d4359f41f2"},
		{2,"fdebf0fa-119e-11e8-89d2-74d4359f41f2"},
		{3,"0749dbf3-32c3-11e8-989f-74d4359f41f2"},
		{4,"89734ad6-9fe6-11e8-885a-9061ae14951f"},      
	};


	void Awake()
	{
		ChangeGender(Gender);
		_userController = UserController.Instance;
		_avatarData = CreateAvatarData();
	}

	// Use this for initialization
	void Start()
	{
		//CreateAvatarData();
		//_userController = UserController.Instance;
		if (_userController != null)
		{
			if (_userController.Avatar.sexo != -1)
			{
				_avatarData = _userController.Avatar;
			}
			else
			{
				Debug.Log("Avatar.sexo == -1");
			}

		}
		else
		{
			Debug.Log("is null");
		}
		LoadAvatarData();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ChangeGender(int gender)
	{
		Gender = gender;
		ChangeHair(HairColor);
		ChangeSkin(SkinColor);
	}

	public void ChangeGender()
	{
		var gender = Gender == 0 ? 1 : 0;
		ChangeGender(gender);
	}

	public void ChangeHair(int color)
	{
		HairColor = color;

	}

	public void ChangeSkin(int color)
	{
		SkinColor = color;
	}

	public void SetupAvatar(int gender, int skinColor, int hairColor)
	{
		Gender = gender;
		ChangeHair(hairColor);
		ChangeSkin(skinColor);
		SetupAvatarData(gender, skinColor, hairColor);
	}

	public void SetupAvatarData(){
		SetupAvatarData(Gender, SkinColor, HairColor);
		_userController.Avatar = _avatarData;
		sendAvatar.avatarData = _avatarData;
		sendAvatar.SaveAvatar();
	}

	public void SetupAvatarData(int gender, int skinColor, int hairColor)
	{
		_avatarData.sexo = gender;
		_avatarData.pele = skinCode[skinColor];
		_avatarData.cabelo = hairCode[hairColor];
	}

   
	private UserAvatar CreateAvatarData(){
		UserAvatar newAvatarData = new UserAvatar
		{
			sexo = Gender,
			cabelo = hairCode[HairColor],
			pele = skinCode[SkinColor]
		};
		return newAvatarData;
		//{ "sexo": 1, "cabelo": "fdebf0fa-119e-11e8-89d2-74d4359f41f2", "pele": "74f0a924-11aa-11e8-89d2-74d4359f41f2" }
        
	}
    
	private void LoadAvatarData(){
		_hairColor = hairCode.FirstOrDefault(x => x.Value == _avatarData.cabelo).Key;
        _skinColor = skinCode.FirstOrDefault(x => x.Value == _avatarData.pele).Key;
        ChangeGender(_avatarData.sexo);	
	}
}
